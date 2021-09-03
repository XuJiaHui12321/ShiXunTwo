using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;
using MySql.Data;

namespace TMS.Common.DB
{
    public class MySqlDapper
    {
        //public object connection = GetConnection(connectionStr);


        /// <summary>
        /// Dapper查询（包含存储过程及sql语句查询）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">存储过程名称或者sql语句</param>
        /// <param name="param">参数化处理</param>
        /// <param name="isStoredProcedure">是否存储过程查询</param>
        /// <returns></returns>
        public static List<T> DapperQuery<T>(string sql, object param, bool? isStoredProcedure = false) where T : new()
        {
            using (IDbConnection con = new MySqlConnection(DbFactory.DbConString))
            {
                CommandType cmdType = (isStoredProcedure ?? true) ? CommandType.StoredProcedure : CommandType.Text;
                try
                {
                    List<T> queryList = con.Query<T>(sql, param, null, true, null, cmdType).ToList();
                    return queryList;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// TSQL查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public static List<T> TSqlQuery<T>(string sql, MySqlParameter[] param, bool? isStoredProcedure = false) where T : new()
        {
            using (MySqlConnection con = new MySqlConnection(DbFactory.DbConString))
            {
                con.Open();
                CommandType cmdType = (isStoredProcedure ?? true) ? CommandType.StoredProcedure : CommandType.Text;
                MySqlCommand command = new MySqlCommand(sql, con);
                command.CommandType = cmdType;
                if (param != null)
                {
                    command.Parameters.AddRange(param);
                }
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    List<T> list = DataReaderToList<T>(reader);
                    return list;
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Dapper增删改（包含存储过程及sql语句查询）
        /// </summary>
        /// <param name="sql">存储过程名称或者sql语句</param>
        /// <param name="param">参数化处理</param>
        /// <param name="isStoredProcedure">是否存储过程查询</param>
        /// <returns></returns>
        public static bool DapperExcute(string sql, object param, bool? isStoredProcedure = false, int? commandTimeout = null)
        {
            bool result = false;
            using (IDbConnection con = new MySqlConnection(DbFactory.DbConString))
            {
                con.Open();
                IDbTransaction tran = con.BeginTransaction();
                CommandType cmdType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;
                try
                {
                    int query = con.Execute(sql, param, tran, commandTimeout, cmdType);
                    tran.Commit();
                    result = true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            }

        }

        /// <summary>
        /// TSQL增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public static bool TSqlExcute(string sql, MySqlParameter[] param, bool? isStoredProcedure = false)
        {
            bool result = false;
            using (MySqlConnection con = new MySqlConnection(DbFactory.DbConString))
            {
                con.Open();
                MySqlTransaction tran = con.BeginTransaction();
                CommandType cmdType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;
                MySqlCommand command = new MySqlCommand(sql, con, tran);
                command.Parameters.AddRange(param);
                try
                {
                    int query = command.ExecuteNonQuery();
                    tran.Commit();
                    result = true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            }
        }

        /// <summary>
        /// 批量数据写入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private static bool BulkInsert<T>(string sql, List<T> dataList) where T : new()
        {
            bool result = false;
            //获取T的公共属性
            Type type = dataList[0].GetType();
            PropertyInfo[] param = type.GetProperties();
            List<string> properotyList = param.Select(p => p.Name).ToList();
            using (MySqlConnection con = new MySqlConnection(DbFactory.DbConString))
            {
                con.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(sql);
                sb.Append(" VALUES");
                int i = 0;
                foreach (var item in dataList)
                {
                    sb.Append("(");
                    for (int j = 0; j < properotyList.Count; j++)
                    {
                        PropertyInfo properotyInfo = item.GetType().GetProperty(properotyList[j]); // 属性的信息
                        object properotyValue = properotyInfo.GetValue(item, null);// 属性的值
                        string cellValue = properotyValue == null ? "" : properotyValue.ToString();// 单元格的值
                        sb.Append("\"");
                        sb.Append(properotyValue);
                        sb.Append("\"");
                        if (j < properotyList.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append(")");
                    if (i++ < dataList.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sql = sb.ToString();

                MySqlTransaction tran = con.BeginTransaction();
                MySqlCommand commd = new MySqlCommand(sql, con, tran);
                try
                {
                    int query = commd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                return result;
            }
        }




        /// <summary>
        /// DataReader To List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<T> DataReaderToList<T>(MySqlDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T t = new T();
                    Type type = t.GetType();
                    var properties = type.GetProperties();
                    foreach (var item in properties)
                    {
                        string name = item.Name;
                        reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + name + "'";
                        bool check = reader.GetSchemaTable().DefaultView.Count > 0;
                        if (check)
                        {
                            if (!item.CanWrite)
                            {
                                continue;
                            }
                            var value = reader[name];
                            if (value != DBNull.Value)
                            {
                                item.SetValue(t, value, null);
                            }
                        }
                    }
                    list.Add(t);
                }
            }
            return list;
        }
    }
}