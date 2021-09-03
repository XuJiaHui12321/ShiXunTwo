using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Set;
using TMS.Model.Entity.BaseInfo;
using Dapper;

namespace TMS.Repository
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        public List<OperatorManage> LoginShow(string OperatorPhone, string OperatorPwd)
        {
            string sql = $"select * from OperatorManage where OperatorPhone={OperatorPhone} and OperatorPwd={OperatorPwd}";
            return MySqlDapper.DapperQuery<OperatorManage>(sql, "");
        }
    }
}
