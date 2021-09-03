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
    /// 货主合同管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("OwnerContractApi")]
    public class OwnerContractController : Controller
    {
        private IOwnerContractRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public OwnerContractController(IOwnerContractRepository _dal)
        {
            dal = _dal;
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OwnerContractIndex")]
        public IActionResult OwnerContractIndex()
        {
            try
            {
                List<OwnerContract> list = dal.OwnerContractShow();
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
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOwnerContract")]
        public IActionResult AddOwnerContract(OwnerContract owner)
        {
            try
            {
                bool result = dal.AddOwnerContract(owner);
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
        /// <param name="OwnerContractId"></param>
        /// <returns></returns>
        [Route("OwnerContractDel")]
        [HttpPost]
        public IActionResult OwnerContractDel(int OwnerContractId)
        {
            try
            {
                bool result = dal.DeleteOwnerContract(OwnerContractId);
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
        /// <param name="OwnerContractId"></param>
        /// <returns></returns>
        [Route("EditOwnerContract")]
        [HttpPost]
        public IActionResult EditOwnerContract(int OwnerContractId)
        {
            try
            {
                OwnerContract result = dal.EditOwnerContract(OwnerContractId);
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
        /// <param name="owner"></param>
        /// <returns></returns>
        [Route("UpdateOwnerContract")]
        [HttpPost]
        public IActionResult UpdateOwnerContract(OwnerContract owner)
        {
            try
            {
                bool result = dal.UpdateOwnerContract(owner);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
