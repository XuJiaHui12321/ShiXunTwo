using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BaseInfo
{
     /// <summary>
     /// 外协管理
     /// </summary>
    public class OutSourceManage
    {
        /// <summary>
        /// Id
        /// </summary>
        public int OutSourceManageId { get; set; }

        /// <summary>
        /// 外协单位名称
        /// </summary>
        public string OutSourceName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string OutSourcePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string OutSourceEmail { get; set; }

        /// <summary>
        /// 外协地址
        /// </summary>
        public string OutSourceAddress { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string FicedTelePhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OutSourceRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OutSourceCreateDate { get; set; }
    }
}
