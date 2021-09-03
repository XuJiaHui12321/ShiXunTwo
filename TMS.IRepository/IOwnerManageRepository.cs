using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BaseInfo;

namespace TMS.IRepository
{
    public interface IOwnerManageRepository
    {
        List<OwnerManage> OwnerManageShow();
        bool AddOwnerManage(OwnerManage owner);
        bool DeleteOwnerManage(int OwnerManageId);
        OwnerManage EditOwnerManage(int OwnerManageId);
        bool UpdateOwnerManage(OwnerManage owner);
    }
}
