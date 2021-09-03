using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BaseInfo;

namespace TMS.IRepository
{
    public interface IOutSourceManageRepository
    {
        List<OutSourceManage> OutSourceManageShow();
        bool AddOutSourceManage(OutSourceManage outSource);
        bool DeleteOutSourceManage(int OutSourceManageId);
        OutSourceManage EditOutSourceManage(int OutSourceManageId);
        bool UpdateOutSourceManage(OutSourceManage outSource);
    }
}
