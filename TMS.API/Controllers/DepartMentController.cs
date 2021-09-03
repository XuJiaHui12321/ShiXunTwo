using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.Redis;
using TMS.IRepository;
using TMS.Model.Entity.Set;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 部门管理
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("DepartMentApi")]
    public class DepartMentController : Controller
    {
        private IDepartMentRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public DepartMentController(IDepartMentRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DepartMentIndex")]
        public IActionResult DepartMentIndex()
        {
            try
            {
                List<DepartMent> list = dal.DepartMentShow();
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
        /// <param name="depart"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDepartMent")]
        public IActionResult AddDepartMent(DepartMent depart)
        {
            try
            {
                bool result = dal.AddDepartMent(depart);
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
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        [Route("DepartMentDel")]
        [HttpPost]
        public IActionResult DepartMentDel(int DepartMentId)
        {
            try
            {
                bool result = dal.DeleteDepartMent(DepartMentId);
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
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        [Route("EditEditDepart")]
        [HttpPost]
        public IActionResult EditEditDepart(int DepartMentId)
        {
            try
            {
                DepartMent result = dal.EditDepartMent(DepartMentId);
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
        [Route("UpdateDepartMent")]
        [HttpPost]
        public IActionResult UpdateRole(DepartMent depart)
        {
            try
            {
                bool result = dal.UpdateDepartMent(depart);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
