using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Contract
{
    /// <summary>
    /// 通用合同管理
    /// </summary>
    public class Contract
    {

        /// <summary>
        /// Id
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public int ContractBh { get; set; }

        /// <summary>
        /// 合同标题
        /// </summary>
        public int ContractTitle { get; set; }

        /// <summary>
        /// 对方单位
        /// </summary>
        public int ContractCompany { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public int ContractType { get; set; }

        /// <summary>
        /// 对方负责人
        /// </summary>
        public int ContractName { get; set; }

        /// <summary>
        /// 签约时间
        /// </summary>
        public int ContractDate { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public int ContractPrice { get; set; }

        /// <summary>
        /// 合同说明
        /// </summary>
        public int ContractRemark { get; set; }

        /// <summary>
        /// 变更条款
        /// </summary>
        public int ContractChange { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public int ContractText { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateDate { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public int ContractState { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public int Approver { get; set; }

        /// <summary>
        /// 审批备注
        /// </summary>
        public int ApproveRemark { get; set; }
    }
}
