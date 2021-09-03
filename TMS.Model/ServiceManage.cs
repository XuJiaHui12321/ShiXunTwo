using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.MainTain
{
    /// <summary>
    /// 维修表
    /// </summary>
    public class ServiceManage
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// 维护管理类型（维修记录 保养 违章  事故 轮胎使用 费用）
        /// </summary>
        public string ServiceManageType { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string ServiceTitle { get; set; }

        /// <summary>
        /// 类型（维修 违章内容 直接经济损失 轮胎品牌）
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string ServiceCarCard { get; set; }

        /// <summary>
        /// 金额（保险公司赔偿）
        /// </summary>
        public string ServicePrice { get; set; }

        /// <summary>
        /// 负责人（违章人 事发人 使用人）
        /// </summary>
        public string ServiceMan { get; set; }

        /// <summary>
        /// 描述（保养项目 违章内容 处罚结果 事故描述）
        /// </summary>
        public string ServiceDescribe { get; set; }

        /// <summary>
        /// 日期（维修 保养 违章 事故 使用）
        /// </summary>
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ServiceRemark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ServiceCreateTime { get; set; }

        /// <summary>
        /// 里程数（公司净损失 规格）
        /// </summary>
        public string ServiceMileage { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int ServiceNum { get; set; }
    }
}
