using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.IRepository
{
    public interface IPurchaseRepository
    {
        List<Purchase> PurchaseShow();
        bool AddPurchase(Purchase purchase);
        bool DeletePurchase(int PurchaseId);
        Purchase EditPurchase(int PurchaseId);
        bool UpdatePurchase(Purchase purchase);
    }
}
