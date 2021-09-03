using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 物资采购
    /// </summary>
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string PurchaseName { get; set; }
        public string PurchaseType { get; set; }
        public string PurchaseTexture { get; set; }
        public string PurchaseSpecification { get; set; }
        public string PurchaseAddress { get; set; }
        public int PurchaseNum { get; set; }
        public string PurchaseUseRemark { get; set; }
        public string proposer { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMentRemark { get; set; }
        public DateTime CreateDate { get; set; }
        public string OwnerContractState { get; set; }
        public string Approver { get; set; }
        public string ApproveRemark { get; set; }
    }
}
