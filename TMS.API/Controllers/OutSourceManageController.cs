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
    /// 外协管理
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("OutSourceManageApi")]
    public class OutSourceManageController : Controller
    {
        private IOutSourceManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public OutSourceManageController(IOutSourceManageRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OutSourceManageIndex")]
        public IActionResult OutSourceManageIndex()
        {
            try
            {
                List<OutSourceManage> list = dal.OutSourceManageShow();
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
        /// <param name="outSource"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOutSourceManage")]
        public IActionResult AddOutSourceManage(OutSourceManage outSource)
        {
            try
            {
                bool result = dal.AddOutSourceManage(outSource);
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
        /// <param name="OutSourceManageId"></param>
        /// <returns></returns>
        [Route("DepartMentDel")]
        [HttpPost]
        public IActionResult DepartMentDel(int OutSourceManageId)
        {
            try
            {
                bool result = dal.DeleteOutSourceManage(OutSourceManageId);
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
        /// <param name="OutSourceManageId"></param>
        /// <returns></returns>
        [Route("EditOutSourceManage")]
        [HttpPost]
        public IActionResult EditOutSourceManage(int OutSourceManageId)
        {
            try
            {
                OutSourceManage result = dal.EditOutSourceManage(OutSourceManageId);
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
        /// <param name="outSource"></param>
        /// <returns></returns>
        [Route("UpdateOutSourceManage")]
        [HttpPost]
        public IActionResult UpdateOutSourceManage(OutSourceManage outSource)
        {
            try
            {
                bool result = dal.UpdateOutSourceManage(outSource);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
