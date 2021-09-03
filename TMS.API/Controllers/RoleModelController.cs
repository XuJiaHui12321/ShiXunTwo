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
    /// 角色管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("RoleModelApi")]
    public class RoleModelController : Controller
    {
        private IRoleModeRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public RoleModelController(IRoleModeRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RoleModelIndex")]
        public IActionResult RoleModelIndex()
        {
            try
            {
                List<RoleModel> list = dal.RoleModelShow();
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
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRoleModel")]
        public IActionResult AddRoleModel(RoleModel role)
        {
            try
            {
                bool result = dal.AddRoleModel(role);
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
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [Route("RoleModelDel")]
        [HttpPost]
        public IActionResult RoleModelDel(int RoleId)
        {
            try
            {
                bool result = dal.DeleteRoleModel(RoleId);
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
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [Route("EditRole")]
        [HttpPost]
        public IActionResult EditRole(int RoleId)
        {
            try
            {
                RoleModel result = dal.EditRole(RoleId);
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
        /// <param name="role"></param>
        /// <returns></returns>
        [Route("UpdateRole")]
        [HttpPost]
        public IActionResult UpdateRole(RoleModel role)
        {
            try
            {
                bool result = dal.UpdateRole(role);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
