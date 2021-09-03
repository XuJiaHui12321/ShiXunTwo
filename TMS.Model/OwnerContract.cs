using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Contract
{
    /// <summary>
    /// 货主合同管理
    /// </summary>
    public class OwnerContract
    {
        /// <summary>
        /// Id
        /// </summary>
        public int OwnerContractId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string OwnerContractBh { get; set; }

        /// <summary>
        /// 合同标题
        /// </summary>
        public string OwnerContractTitle { get; set; }

        /// <summary>
        /// 货主单位
        /// </summary>
        public string OwnerContractCompany { get; set; }

        /// <summary>
        /// 货主负责人
        /// </summary>
        public string OwnerContractName { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        public int CirCuitManage_Id { get; set; }

        /// <summary>
        /// 吨运价
        /// </summary>
        public decimal TonFare { get; set; }

        /// <summary>
        /// 包车条件吨位
        /// </summary>
        public string IncludeCarTon { get; set; }

        /// <summary>
        /// 包车金额
        /// </summary>
        public decimal IncludeCarPrice { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// 签约时间
        /// </summary>
        public DateTime ContractDate { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal OwnerContractPrice { get; set; }

        /// <summary>
        /// 合同说明
        /// </summary>
        public string ContartRemark { get; set; }

        /// <summary>
        /// 变更条款
        /// </summary>
        public string ContartChange { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string ContartText { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 审批状态（待审批  已同意   已拒绝）
        /// </summary>
        public string OwnerContractState { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 审批备注
        /// </summary>
        public string ApproveRemark { get; set; }
    }
}
