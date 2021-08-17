using System;
using LogisticsManagementSystem_MODEL;
using LogisticsManagementSystem_IDAL;
using LogisticsManagementSystem_Common;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace LogisticsManagementSystem_DAL
{
    public class Functions : IFunctions
    {
        /// <summary>
        /// 查询二级菜单
        /// </summary>
        /// <param name="FunctionErId"></param>
        /// <returns></returns>
        public List<FunctionModel> ErFunctionModels(int FunctionErId)
        {
            using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            {
                List<FunctionModel> listfunction = Dbconnection.Query<FunctionModel>($"SELECT * FROM Functions WHERE FunctionErId={FunctionErId}").ToList();
                return listfunction;
            }
        }

        /// <summary>
        /// 查询所有菜单明细
        /// </summary>
        /// <returns></returns>
        public List<FunctionModel> GetFunctionModels()
        {
            using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            {
                List<FunctionModel> listfunction = Dbconnection.Query<FunctionModel>("SELECT FunctionId,FunctionName,FunctionErId,FunctionRoute from Functions").ToList();
                return listfunction;
            }
        }
        /// <summary>
        /// 根据用户查询用户的菜单权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<FunctionModel> GetFunctionModels(int userId)
        {
            using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            {
                List<FunctionModel> listfunction = Dbconnection.Query<FunctionModel>($"SELECT C.FunctionId,C.FunctionName,C.FunctionErId,C.FunctionRoute FROM UserRole A JOIN  RoleFunction B ON A.RoleId=B.RoleId JOIN Functions C ON C.FunctionId=B.FunctionId WHERE  A.UserId={userId}").ToList();
                return listfunction;
            }
        }
    }
}
