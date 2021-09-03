using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Set;

namespace TMS.IRepository
{
    public interface IRoleModeRepository
    {
        List<RoleModel> RoleModelShow();
        bool AddRoleModel(RoleModel role);
        bool DeleteRoleModel(int RoleId);
        RoleModel EditRole(int RoleId);
        bool UpdateRole(RoleModel role);
    }
}
