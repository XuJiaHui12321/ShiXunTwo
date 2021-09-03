using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Set;

namespace TMS.IRepository
{
    public interface IDepartMentRepository
    {
        List<DepartMent> DepartMentShow();
        bool AddDepartMent(DepartMent depart);
        bool DeleteDepartMent(int DepartMentId);
        DepartMent EditDepartMent(int DepartMentId);
        bool UpdateDepartMent(DepartMent depart);
    }
}
