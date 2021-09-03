using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.GoodsMaterial
{
    /// <summary>
    /// 应收费用管理
    /// </summary>
    public class Receivable
    {
        public int ReceivableId { get; set; }
        public string ReceivableBh { get; set; }
        public string ReceivableCompany { get; set; }
        public string PayType { get; set; }
        public string Tonnage { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime BusinessDate { get; set; }
        public string Principal { get; set; }
        public string ReceivableRemark { get; set; }
        public string ContractChange { get; set; }
        public string ContractText { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateState { get; set; }
        public string CreateName { get; set; }
        public DateTime ReceivableDate { get; set; }
    }
}
