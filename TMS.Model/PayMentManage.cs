using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 付款管理
    /// </summary>
    public class PayMentManage
    {
        public int PayMentManageId               { get; set; }
        public string PayMentManageTitle         { get; set; }
        public string UseRemark   				 { get; set; }
        public decimal PayPrice    				 { get; set; }
        public string PayType    				 { get; set; }
        public string PayCompany   			 { get; set; }
        public string OpenBank   				 { get; set; }
        public string BankAccount   			 { get; set; }
        public string Principal  				 { get; set; }
        public DateTime PayDate   					 { get; set; }
        public string PayMentRemark 			 { get; set; }
        public string PayMentText    		 { get; set; }
        public DateTime CreateDate  				 { get; set; }
        public string OwnerContractState  { get; set; }
        public string Approver    				 { get; set; }
        public string ApproveRemark { get; set; }
    }
}
