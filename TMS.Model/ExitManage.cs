using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel
{
    /// <summary>
    /// 离职管理
    /// </summary>
    public class ExitManage
    {

        /// <summary>
        /// Id
        /// </summary>
        public int ExitManageId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int DepartMent_Id { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public int Position_Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public int UsersInfo_Id { get; set; }

        /// <summary>
        /// 上级负责人
        /// </summary>
        public int EManage_Id { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime ExitDate { get; set; }

        /// <summary>
        /// 离职原因
        /// </summary>
        public string ExitCause { get; set; }

        /// <summary>
        /// 审批状态（待审批  已同意   已拒绝）
        /// </summary>
        public string ExitState { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 审批备注
        /// </summary>
        public string ApproveRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ExitCreateDate { get; set; }
    }
}
