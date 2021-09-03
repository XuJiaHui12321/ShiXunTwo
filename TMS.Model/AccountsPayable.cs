using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 应付费用管理
    /// </summary>
    public class AccountsPayable
    {
        /// <summary>
        /// Id
        /// </summary>
        public int AccountsPayableId { get; set; }

        /// <summary>
        /// 业务单号
        /// </summary>
        public string AccountsPayableBh { get; set; }

        /// <summary>
        /// 外协单位
        /// </summary>
        public string AccountsPayableCompany { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 吨位
        /// </summary>
        public string Tonnage { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime BusinessDate { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ReceivableRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 核对状态（已核对/未核对）
        /// </summary>
        public string CreateState { get; set; }

        /// <summary>
        /// 核对人
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 核对时间
        /// </summary>
        public DateTime ReceivableDate { get; set; }
    }
}
