using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Set;

namespace TMS.IRepository
{
    public interface IUsersRepository
    {
        //显示查询
        List<OperatorManage> LoginShow(string OperatorPhone, string OperatorPwd);
    }
}
