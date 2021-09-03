using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.IRepository
{
    public interface IBaseRepository
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        List<T> Query<T>(string sql, object param) where T : class, new();


        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        bool Execute(string sql, object param);

    }
}
