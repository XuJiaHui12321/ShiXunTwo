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
    /// 物资采购
    /// </summary>
    [ApiController]
    [Route("PurchaseApi")]
    public class PurchaseController : Controller
    {
        private IPurchaseRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public PurchaseController(IPurchaseRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PurchaseIndex")]
        public IActionResult PurchaseIndex()
        {
            try
            {
                List<Purchase> list = dal.PurchaseShow();
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
        [Route("AddPurchase")]
        public IActionResult AddPurchase(Purchase receivable)
        {
            try
            {
                bool result = dal.AddPurchase(receivable);
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
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        [Route("PurchaseDel")]
        [HttpPost]
        public IActionResult PurchaseDel(int PurchaseId)
        {
            try
            {
                bool result = dal.DeletePurchase(PurchaseId);
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
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        [Route("EditPurchase")]
        [HttpPost]
        public IActionResult EditPurchase(int PurchaseId)
        {
            try
            {
                Purchase result = dal.EditPurchase(PurchaseId);
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
        [Route("UpdatePurchase")]
        [HttpPost]
        public IActionResult UpdatePurchase(Purchase exit)
        {
            try
            {
                bool result = dal.UpdatePurchase(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
