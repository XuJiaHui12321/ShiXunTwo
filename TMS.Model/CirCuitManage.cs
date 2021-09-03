using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BaseInfo
{
    public class CirCuitManage
    {

        /// <summary>
        /// Id
        /// </summary>
        public int CirCuitManageId { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string CirCuitName { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public string StartAddress { get; set; }

        /// <summary>
        /// 详细起点
        /// </summary>
        public string StartDetailAddress { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        public string EedAdress { get; set; }

        /// <summary>
        /// 详细终点
        /// </summary>
        public string EndDetailAddress { get; set; }

        /// <summary>
        /// 是否外协（1是0否）
        /// </summary>
        public int SelectOutSource { get; set; }

        /// <summary>
        /// 货主姓名
        /// </summary>
        public string CirOwnerName { get; set; }

        /// <summary>
        /// 货主手机号
        /// </summary>
        public string CirOwnerPhone { get; set; }

        /// <summary>
        /// 货主单位
        /// </summary>
        public string CirOwnerCompany { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string CirCuitRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime  CirCuitCreateDate { get; set; }
    }
}
