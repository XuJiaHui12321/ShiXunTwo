using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.MainTain;

namespace TMS.IRepository
{
    public interface IMainTainRopository
    {
        List<ServiceManage> MainTainShow();
        bool AddServiceManage(ServiceManage service);
        bool DeleteServiceManage(int ServiceId);
        ServiceManage EditServiceManage(int ServiceId);
        bool UpdateServiceManage(ServiceManage service);
    }
}
