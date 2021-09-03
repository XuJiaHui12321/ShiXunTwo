using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Personnel;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 离职管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("ExitManageApi")]
    public class ExitManageController : Controller
    {
        private IExitManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public ExitManageController(IExitManageRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ExitManageIndex")]
        public IActionResult ExitManageIndex()
        {
            try
            {
                List<ExitManage> list = dal.ExitManageShow();
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
        /// <param name="exit"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddExitManage")]
        public IActionResult AddExitManage(ExitManage exit)
        {
            try
            {
                bool result = dal.AddExitManage(exit);
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
        /// <param name="ExitManageId"></param>
        /// <returns></returns>
        [Route("ExitManageDel")]
        [HttpPost]
        public IActionResult ExitManageDel(int ExitManageId)
        {
            try
            {
                bool result = dal.DeleteExitManage(ExitManageId);
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
        /// <param name="ExitManageId"></param>
        /// <returns></returns>
        [Route("EditExitManage")]
        [HttpPost]
        public IActionResult EditExitManage(int ExitManageId)
        {
            try
            {
                ExitManage result = dal.EditExitManage(ExitManageId);
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
        [Route("UpdateExitManage")]
        [HttpPost]
        public IActionResult UpdateExitManage(ExitManage exit)
        {
            try
            {
                bool result = dal.UpdateExitManage(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
