using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Contract;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 承运合同管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("CarrierContractApi")]
    public class CarrierContractController : Controller
    {
        private ICarrierContractRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public CarrierContractController(ICarrierContractRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CarrierContractIndex")]
        public IActionResult CarrierContractIndex()
        {
            try
            {
                List<CarrierContract> list = dal.CarrierContractShow();
                return Json(list);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCarrierContract")]
        public IActionResult AddCarrierContract(CarrierContract carrier)
        {
            try
            {
                bool result = dal.AddCarrierContract(carrier);
                return Json(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarrierContractId"></param>
        /// <returns></returns>
        [Route("CarrierContractDel")]
        [HttpPost]
        public IActionResult CarrierContractDel(int CarrierContractId)
        {
            try
            {
                bool result = dal.DeleteCarrierContract(CarrierContractId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="CarrierContractId"></param>
        /// <returns></returns>
        [Route("EditEditcarrier")]
        [HttpPost]
        public IActionResult EditEditcarrier(int CarrierContractId)
        {
            try
            {
                CarrierContract result = dal.EditCarrierContract(CarrierContractId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        [Route("UpdateCarrierContract")]
        [HttpPost]
        public IActionResult UpdateCarrierContract(CarrierContract carrier)
        {
            try
            {
                bool result = dal.UpdateCarrierContract(carrier);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
