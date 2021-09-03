using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 销项发票管理
    /// </summary>
    public class OutputInvoice
    {
        public int      OutputInvoiceId         { get; set; }
        public string   OutputInvoiceBh         { get; set; }
        public string   OutputInvoiceCompany    { get; set; }
        public string   OutputInvoiceType       { get; set; }
        public decimal  OutputInvoicePrice      { get; set; }
        public int      TaxRate                 { get; set; }
        public decimal  TaxPrice                { get; set; }
        public DateTime ReceiptsInvoiceDate     { get; set; }
        public string   ReceivableRemark        { get; set; }
        public string   Principal               { get; set; }
        public DateTime OutputCreateDate        { get; set; }
    }
}
