using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Personnel;

namespace TMS.IRepository
{
    public interface IRegularManageRepository
    {
        List<RegularManage> RegularManageShow();
        bool AddRegularManage(RegularManage regular);
        bool DeleteRegularManage(int RegularManageId);
        RegularManage EditRegularManage(int RegularManageId);
        bool UpdateRegularManage(RegularManage regular);
    }
}
