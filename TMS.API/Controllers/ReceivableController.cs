using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.GoodsMaterial;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 应收费用管理
    /// </summary>
    [ApiController]
    [Route("ReceivableApi")]
    public class ReceivableController : Controller
    {

        private IReceivableRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public ReceivableController(IReceivableRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ReceivableIndex")]
        public IActionResult ReceivableIndex()
        {
            try
            {
                List<Receivable> list = dal.ReceivableShow();
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
        [Route("AddReceivable")]
        public IActionResult AddReceivable(Receivable receivable)
        {
            try
            {
                bool result = dal.AddReceivable(receivable);
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
        /// <param name="ReceivableId"></param>
        /// <returns></returns>
        [Route("ReceivableDel")]
        [HttpPost]
        public IActionResult ReceivableDel(int ReceivableId)
        {
            try
            {
                bool result = dal.DeleteReceivable(ReceivableId);
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
        /// <param name="ReceivableId"></param>
        /// <returns></returns>
        [Route("EditReceivable")]
        [HttpPost]
        public IActionResult EditReceivable(int ReceivableId)
        {
            try
            {
                Receivable result = dal.EditReceivable(ReceivableId);
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
        [Route("UpdateReceivable")]
        [HttpPost]
        public IActionResult UpdateReceivable(Receivable exit)
        {
            try
            {
                bool result = dal.UpdateReceivable(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


    }
}
