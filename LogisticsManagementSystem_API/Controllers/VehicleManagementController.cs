using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsManagementSystem_MODEL;
using LogisticsManagementSystem_IDAL;
using System.IO;

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
        [HttpPost,Route("ImageUp")]
        public async Task<IActionResult> ImageUp()
        {
            //List<IFormFile> files
           List<IFormFile> files = (List<IFormFile>)Request.Form.Files;
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                var filePath = Directory.GetCurrentDirectory() + @"\image\" + formFile.FileName;

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return Ok("1");
        }
        [HttpGet, Route("getimg")]
        public IActionResult Getimg()
        {
            using (var sw = new FileStream(Directory.GetCurrentDirectory() + @"\image\catemenubg.png", FileMode.Open))
            {
                var bytes = new byte[sw.Length];
                sw.Read(bytes, 0, bytes.Length);
                sw.Close();
                return new FileContentResult(bytes, "image/jpeg");
            }
        }

    }
}
