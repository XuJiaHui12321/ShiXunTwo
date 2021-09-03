using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Personnel;

namespace TMS.IRepository
{
    public interface IUsersInfoRepository
    {
        List<UsersInfo> UsersInfoShow();
        bool AddUsersInfo(UsersInfo users);
        bool DeleteUsersInfo(int UsersInfoId);
        UsersInfo EditUsersInfo(int UsersInfoId);
        bool UpdateUsersInfo(UsersInfo users);
    }
}
