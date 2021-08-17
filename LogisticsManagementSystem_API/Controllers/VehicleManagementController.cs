using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsManagementSystem_MODEL;
using LogisticsManagementSystem_IDAL;

namespace LogisticsManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleManagementController : ControllerBase
    {
        IVehicleManagement vehicleManagement;
        public VehicleManagementController(IVehicleManagement _vehicleManagement)
        {
            vehicleManagement = _vehicleManagement;
        }
        [Route("show")]
        [HttpGet]
        public ActionResult Show(int page,int size,string BrandAndModel,string LicensePlateNumber,string Company,string DriverName)
        {
            List<VehicleManagementModel> vehicleManagementModels = vehicleManagement.GetVehicleManagementModels(out int pageCount, out int totalRecordCount, size, page, BrandAndModel, LicensePlateNumber, Company, DriverName);
            return Ok(new { data = vehicleManagementModels, pageCount = pageCount, totalRecordCount = totalRecordCount, size = size, page = page });
        }
    }
}
