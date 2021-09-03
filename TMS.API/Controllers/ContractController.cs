using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Contract;
using TMS.Model.Entity.GoodsMaterial;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 应收费用管理
    /// </summary>
    [ApiController]
    [Route("ContractApi")]
    public class ContractController : Controller
    {
        private IContractRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public ContractController(IContractRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ContractIndex")]
        public IActionResult ContractIndex()
        {
            try
            {
                List<Contract> list = dal.ContractShow();
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
        /// <param name="receivable"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddContract")]
        public IActionResult AddContract(Contract receivable)
        {
            try
            {
                bool result = dal.AddContract(receivable);
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
        /// <param name="ContractId"></param>
        /// <returns></returns>
        [Route("ContractDel")]
        [HttpPost]
        public IActionResult ContractDel(int ContractId)
        {
            try
            {
                bool result = dal.DeleteContract(ContractId);
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
        /// <param name="ContractId"></param>
        /// <returns></returns>
        [Route("EditContract")]
        [HttpPost]
        public IActionResult EditContract(int ContractId)
        {
            try
            {
                Contract result = dal.EditContract(ContractId);
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
        /// <param name="exit"></param>
        /// <returns></returns>
        [Route("UpdateContract")]
        [HttpPost]
        public IActionResult UpdateContract(Contract exit)
        {
            try
            {
                bool result = dal.UpdateContract(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
