using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Set;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 操作员管理
    /// </summary>
    [ApiController]
    [Route("OperatorManageApi")]
    public class OperatorManageController : Controller
    {
        private IOperatorManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public OperatorManageController(IOperatorManageRepository _dal)
        {
            dal = _dal;
        }


        /// <summary>
        /// 操作员管理显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OperatorManageIndex")]
        public IActionResult OperatorManageIndex()
        {
            try
            {
                List<OperatorManage> list = dal.OperatorManageShow();
                return Json(list);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 新增操作员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOperatorManage")]
        public IActionResult AddOperatorManage(OperatorManage operatorManage)
        {
            try
            {
                bool result = dal.AddOperatorManage(operatorManage);
                return Json(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除操作员
        /// </summary>
        /// <param name="OperatorManageId"></param>
        /// <returns></returns>
        [Route("OperatorDel")]
        [HttpPost]
        public IActionResult OperatorDel(int OperatorManageId)
        {
            try
            {
                bool result = dal.DeleteOperator(OperatorManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }

        /// <summary>
        /// 反填该操作员
        /// </summary>
        /// <param name="OperatorManageId"></param>
        /// <returns></returns>
        [Route("EditOperator")]
        [HttpPost]
        public IActionResult EditOperator(int OperatorManageId)
        {
            try
            {
                OperatorManage result = dal.EditOperatorManage(OperatorManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


        /// <summary>
        /// 修改该操作员
        /// </summary>
        /// <param name="operatorManage"></param>
        /// <returns></returns>
        [Route("UpdateOperatorManage")]
        [HttpPost]
        public IActionResult UpdateOperatorManage(OperatorManage operatorManage)
        {
            try
            {
                bool result = dal.UpdateOperator(operatorManage);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


    }

}
