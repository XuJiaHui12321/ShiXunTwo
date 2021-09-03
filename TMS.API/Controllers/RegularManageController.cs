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
    /// 转正管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("RegularManageApi")]
    public class RegularManageController : Controller
    {
        private IRegularManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public RegularManageController(IRegularManageRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RegularManageIndex")]
        public IActionResult RegularManageIndex()
        {
            try
            {
                List<RegularManage> list = dal.RegularManageShow();
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
        /// <param name="regular"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRegularManage")]
        public IActionResult AddRegularManage(RegularManage regular)
        {
            try
            {
                bool result = dal.AddRegularManage(regular);
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
        /// <param name="RegularManageId"></param>
        /// <returns></returns>
        [Route("RegularManageDel")]
        [HttpPost]
        public IActionResult RegularManageDel(int RegularManageId)
        {
            try
            {
                bool result = dal.DeleteRegularManage(RegularManageId);
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
        /// <param name="RegularManageId"></param>
        /// <returns></returns>
        [Route("EditEditDepart")]
        [HttpPost]
        public IActionResult EditEditDepart(int RegularManageId)
        {
            try
            {
                RegularManage result = dal.EditRegularManage(RegularManageId);
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
        /// <param name="regular"></param>
        /// <returns></returns>
        [Route("UpdateDepartMent")]
        [HttpPost]
        public IActionResult UpdateRole(RegularManage regular)
        {
            try
            {
                bool result = dal.UpdateRegularManage(regular);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
