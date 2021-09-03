using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Personnel;

namespace TMS.IRepository
{
    public interface IExitManageRepository
    {
        List<ExitManage> ExitManageShow();
        bool AddExitManage(ExitManage exit);
        bool DeleteExitManage(int ExitManageId);
        ExitManage EditExitManage(int ExitManageId);
        bool UpdateExitManage(ExitManage exit);
    }
}
