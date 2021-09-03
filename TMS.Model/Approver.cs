using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.ApprovalProcess
{
    /// <summary>
    /// 审批记录
    /// </summary>
    public class Approver
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ApproverId { get; set; }

        /// <summary>
        /// 审批结果
        /// </summary>
        public string ApproverResult { get; set; }

        /// <summary>
        /// 审批备注
        /// </summary>
        public string ApproverRemark { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime ApproverTime { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string Approveror { get; set; }

        /// <summary>
        /// 与其他表绑定
        /// </summary>
        public int ForeignKey { get; set; }
    }
}
