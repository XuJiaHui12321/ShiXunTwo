using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagementSystem_MODEL;

namespace LogisticsManagementSystem_IDAL
{
    public interface IVehicleManagement
    {
        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <returns></returns>
        List<VehicleManagementModel> GetVehicleManagementModels(out int pageCount, out int totalRecordCount, int size, int page, string BrandAndModel, string LicensePlateNumber, string Company, string DriverName);
        /// <summary>
        /// 添加车辆管理
        /// </summary>
        /// <param name="vehicleManagementModel"></param>
        /// <returns></returns>
        int AddVehicleManagement(VehicleManagementModel vehicleManagementModel);
    }
}
