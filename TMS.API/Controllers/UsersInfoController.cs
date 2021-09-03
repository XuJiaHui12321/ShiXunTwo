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
    /// 员工登记
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("UsersInfoApi")]
    public class UsersInfoController : Controller
    {
        private IUsersInfoRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public UsersInfoController(IUsersInfoRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UsersInfoIndex")]
        public IActionResult UsersInfoIndex()
        {
            try
            {
                List<UsersInfo> list = dal.UsersInfoShow();
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
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUsersInfo")]
        public IActionResult AddUsersInfo(UsersInfo users)
        {
            try
            {
                bool result = dal.AddUsersInfo(users);
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
        /// <param name="UsersInfoId"></param>
        /// <returns></returns>
        [Route("UsersInfoDel")]
        [HttpPost]
        public IActionResult UsersInfoDel(int UsersInfoId)
        {
            try
            {
                bool result = dal.DeleteUsersInfo(UsersInfoId);
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
        /// <param name="UsersInfoId"></param>
        /// <returns></returns>
        [Route("EditUsersInfo")]
        [HttpPost]
        public IActionResult EditUsersInfo(int UsersInfoId)
        {
            try
            {
                UsersInfo result = dal.EditUsersInfo(UsersInfoId);
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
        /// <param name="depart"></param>
        /// <returns></returns>
        [Route("UpdateUsersInfo")]
        [HttpPost]
        public IActionResult UpdateUsersInfo(UsersInfo users)
        {
            try
            {
                bool result = dal.UpdateUsersInfo(users);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
