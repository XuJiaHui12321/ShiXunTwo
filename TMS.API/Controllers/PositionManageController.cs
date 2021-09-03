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
    /// 职位管理
    /// </summary>
    [ApiController]
    [Route("PositionManageApi")]
    public class PositionManageController : Controller
    {
        private IPositionManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public PositionManageController(IPositionManageRepository _dal)
        {
            dal = _dal;
        }


        /// <summary>
        /// 职位管理显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PositionManageIndex")]
        public IActionResult PositionManageIndex()
        {
            try
            {
                List<PositionManage> list = dal.PositionManageShow();
                return Json(list);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 新增职位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPositionManage")]
        public IActionResult AddPositionManage(PositionManage position)
        {
            try
            {
                 bool result = dal.AddPositionManage(position);
                 return Json(result);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除该职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        [Route("PositionDel")]
        [HttpPost]
        public IActionResult PositionDel(int PositionManageId)
        {
            try
            {
                bool result = dal.DeletePosition(PositionManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }

        /// <summary>
        /// 反填该职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        [Route("EditPosition")]
        [HttpPost]
        public IActionResult EditPosition(int PositionManageId)
        {
            try
            {
                PositionManage result = dal.EditPositionManage(PositionManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [Route("UpdatePositionManage")]
        [HttpPost]
        public IActionResult UpdatePositionManage(PositionManage position)
        {
            try
            {
                bool result = dal.UpdatePosition(position);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


    }
}
