using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 进项发票管理
    /// </summary>
    public class ReceiptsInvoice
    {
        public int ReceiptsInvoiceId { get; set; }
        public string ReceiptsInvoiceBh { get; set; }
        public string ReceiptsInvoiceCompany { get; set; }
        public string ReceiptsInvoiceType { get; set; }
        public int TaxRate { get; set; }
        public decimal TaxPrice { get; set; }
        public DateTime ReceiptsInvoiceDate { get; set; }
        public string ReceivableRemark { get; set; }
        public string Principal { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
