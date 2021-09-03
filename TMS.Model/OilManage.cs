using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BaseInfo
{
    public class OilManage
    {
        /// <summary>
        ///  Id
        /// </summary>
        public int OilManageId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string OilCarCard { get; set; }

        /// <summary>
        /// 加油费用/元
        /// </summary>
        public float OilPrice { get; set; }

        /// <summary>
        /// 加油量/L
        /// </summary>
        public float OilQuantity { get; set; }

        /// <summary>
        /// 起始公里数
        /// </summary>
        public float StarKm { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string Oiler { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OilRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  OilCreateDate { get; set; }
    }
}
