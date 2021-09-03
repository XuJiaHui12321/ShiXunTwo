using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 货主管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("OwnerManageApi")]
    public class OwnerManageController : Controller
    {
        private IOwnerManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public OwnerManageController(IOwnerManageRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OwnerManageIndex")]
        public IActionResult OwnerManageIndex()
        {
            try
            {
                List<OwnerManage> list = dal.OwnerManageShow();
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
        [Route("AddOwnerManage")]
        public IActionResult AddOwnerManage(OwnerManage owner)
        {
            try
            {
                bool result = dal.AddOwnerManage(owner);
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
        /// <param name="OwnerManageId"></param>
        /// <returns></returns>
        [Route("OwnerManageDel")]
        [HttpPost]
        public IActionResult OwnerManageDel(int OwnerManageId)
        {
            try
            {
                bool result = dal.DeleteOwnerManage(OwnerManageId);
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
        /// <param name="OwnerManageId"></param>
        /// <returns></returns>
        [Route("OwnerManage")]
        [HttpPost]
        public IActionResult EditOwnerManage(int OwnerManageId)
        {
            try
            {
                OwnerManage result = dal.EditOwnerManage(OwnerManageId);
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
        [Route("UpdateOwnerManage")]
        [HttpPost]
        public IActionResult UpdateOwnerManage(OwnerManage owner)
        {
            try
            {
                bool result = dal.UpdateOwnerManage(owner);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
