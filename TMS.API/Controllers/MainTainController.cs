using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.MainTain;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 维修管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("MainTainApi")]
    public class MainTainController : Controller
    {
        private IMainTainRopository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public MainTainController(IMainTainRopository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MainTainIndex")]
        public IActionResult MainTainIndex()
        {
            try
            {
                List<ServiceManage> list = dal.MainTainShow();
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
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMainTain")]
        public IActionResult AddMainTain(ServiceManage service)
        {
            try
            {
                bool result = dal.AddServiceManage(service);
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
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        [Route("MainTainDel")]
        [HttpPost]
        public IActionResult MainTainDel(int ServiceId)
        {
            try
            {
                bool result = dal.DeleteServiceManage(ServiceId);
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
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        [Route("EditMainTain")]
        [HttpPost]
        public IActionResult EditMainTain(int ServiceId)
        {
            try
            {
                ServiceManage result = dal.EditServiceManage(ServiceId);
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
        /// <param name="service"></param>
        /// <returns></returns>
        [Route("UpdateMainTain")]
        [HttpPost]
        public IActionResult UpdateMainTain(ServiceManage service)
        {
            try
            {
                bool result = dal.UpdateServiceManage(service);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
