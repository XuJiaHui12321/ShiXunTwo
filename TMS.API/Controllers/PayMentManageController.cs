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
    /// 付款管理
    /// </summary>
    [ApiController]
    [Route("PayMentManageApi")]
    public class PayMentManageController : Controller
    {
        private IPayMentManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public PayMentManageController(IPayMentManageRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PayMentManageIndex")]
        public IActionResult PayMentManageIndex()
        {
            try
            {
                List<PayMentManage> list = dal.Show();
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
        [Route("AddPayMentManage")]
        public IActionResult AddPayMentManage(PayMentManage receivable)
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
        /// <param name="PayMentManageId"></param>
        /// <returns></returns>
        [Route("PayMentManageDel")]
        [HttpPost]
        public IActionResult PayMentManageDel(int PayMentManageId)
        {
            try
            {
                bool result = dal.Delete(PayMentManageId);
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
        /// <param name="PayMentManageId"></param>
        /// <returns></returns>
        [Route("EditPayMentManage")]
        [HttpPost]
        public IActionResult EditPayMentManage(int PayMentManageId)
        {
            try
            {
                PayMentManage result = dal.Edit(PayMentManageId);
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
        [Route("UpdatePayMentManage")]
        [HttpPost]
        public IActionResult UpdatePayMentManage(PayMentManage exit)
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
