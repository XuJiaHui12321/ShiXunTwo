using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BaseInfo
{
    /// <summary>
    /// 货主管理
    /// </summary>
    public class OwnerManage
    {
        /// <summary>
        /// 货主Id
        /// </summary>
        public int OwnerManageId { get; set; }

        /// <summary>
        /// 货主姓名
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string OwnerPhone { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string OwnerCompanyName { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string OwnerAddress { get; set; }

        /// <summary>
        /// 驾驶证有效日期
        /// </summary>
        public DateTime  CarCardDate { get; set; }

        /// <summary>
        /// 驾驶证照片
        /// </summary>
        public string CarCardPicture { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OwnerRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  CreateDate { get; set; }
    }
}
