using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BaseInfo
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    public class CarManage
    {
        /// <summary>
        /// 车辆Id
        /// </summary>
        public int CarManageId { get; set; }

        /// <summary>
        /// 厂牌型号
        /// </summary>
        public string FactoryPlate { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarPlate { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public string SubordinateCompany { get; set; }

        /// <summary>
        /// 车型（长宽高）
        /// </summary>
        public string Cartype { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string CarColor { get; set; }

        /// <summary>
        /// 购置日期
        /// </summary>
        public DateTime  BuyDate { get; set; }

        /// <summary>
        /// 运营证号
        /// </summary>
        public string OperationPlate { get; set; }

        /// <summary>
        /// 保险到期时间
        /// </summary>
        public DateTime InsuranceExpriration { get; set; }

        /// <summary>
        /// 年检到期时间
        /// </summary>
        public DateTime AnnualInspection { get; set; }

        /// <summary>
        /// 保养公里设置
        /// </summary>
        public string UpKeepKm { get; set; }

        /// <summary>
        /// 车辆照片
        /// </summary>
        public string CarPicture { get; set; }

        /// <summary>
        /// 保险卡照片
        /// </summary>
        public string UpKeepKmPicture { get; set; }
    }
}
