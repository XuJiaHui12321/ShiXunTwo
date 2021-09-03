using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.GoodsMaterial;

namespace TMS.IRepository
{
    public interface IReceivableRepository
    {
        List<Receivable> ReceivableShow();
        bool AddReceivable(Receivable rece);
        bool DeleteReceivable(int ReceivableId);
        Receivable EditReceivable(int ReceivableId);
        bool UpdateReceivable(Receivable rece);
    }
}
