using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 物资领用
    /// </summary>
    [ApiController]
    [Route("GoodReceiveApi")]
    public class GoodReceiveController : Controller
    {
        private IGoodReceiveRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public GoodReceiveController(IGoodReceiveRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GoodReceiveIndex")]
        public IActionResult GoodReceiveIndex()
        {
            try
            {
                List<GoodReceive> list = dal.Show();
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
        /// <param name="receivable"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddGoodReceive")]
        public IActionResult AddGoodReceive(GoodReceive receivable)
        {
            try
            {
                bool result = dal.Add(receivable);
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
        /// <param name="GoodReceiveId"></param>
        /// <returns></returns>
        [Route("GoodReceiveDel")]
        [HttpPost]
        public IActionResult GoodReceiveDel(int GoodReceiveId)
        {
            try
            {
                bool result = dal.Delete(GoodReceiveId);
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
        /// <param name="GoodReceiveId"></param>
        /// <returns></returns>
        [Route("EditGoodReceive")]
        [HttpPost]
        public IActionResult EditGoodReceive(int GoodReceiveId)
        {
            try
            {
                GoodReceive result = dal.Edit(GoodReceiveId);
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
        [Route("UpdateGoodReceive")]
        [HttpPost]
        public IActionResult UpdateGoodReceive(GoodReceive exit)
        {
            try
            {
                bool result = dal.Update(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
