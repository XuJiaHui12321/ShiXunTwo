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
    /// 进项发票管理
    /// </summary>
    [ApiController]
    [Route("ReceiptsInvoiceApi")]
    public class ReceiptsInvoiceController : Controller
    {
        private IReceiptsInvoiceRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public ReceiptsInvoiceController(IReceiptsInvoiceRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ReceiptsInvoiceIndex")]
        public IActionResult ReceiptsInvoiceIndex()
        {
            try
            {
                List<ReceiptsInvoice> list = dal.Show();
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
        [Route("AddReceiptsInvoice")]
        public IActionResult AddReceiptsInvoice(ReceiptsInvoice receivable)
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
        /// <param name="ReceiptsInvoiceId"></param>
        /// <returns></returns>
        [Route("ReceiptsInvoiceDel")]
        [HttpPost]
        public IActionResult ReceiptsInvoiceDel(int ReceiptsInvoiceId)
        {
            try
            {
                bool result = dal.Delete(ReceiptsInvoiceId);
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
        /// <param name="ReceiptsInvoiceId"></param>
        /// <returns></returns>
        [Route("EditReceiptsInvoice")]
        [HttpPost]
        public IActionResult EditReceiptsInvoice(int ReceiptsInvoiceId)
        {
            try
            {
                ReceiptsInvoice result = dal.Edit(ReceiptsInvoiceId);
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
        [Route("UpdateReceiptsInvoice")]
        [HttpPost]
        public IActionResult UpdateReceiptsInvoice(ReceiptsInvoice exit)
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
