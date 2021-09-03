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
    /// 销项发票管理
    /// </summary>
    [ApiController]
    [Route("OutputInvoiceApi")]
    public class OutputInvoiceController : Controller
    {
        private IOutputInvoiceRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public OutputInvoiceController(IOutputInvoiceRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OutputInvoiceIndex")]
        public IActionResult OutputInvoiceIndex()
        {
            try
            {
                List<OutputInvoice> list = dal.Show();
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
        [Route("AddOutputInvoice")]
        public IActionResult AddOutputInvoice(OutputInvoice receivable)
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
        /// <param name="OutputInvoiceId"></param>
        /// <returns></returns>
        [Route("OutputInvoiceDel")]
        [HttpPost]
        public IActionResult OutputInvoiceDel(int OutputInvoiceId)
        {
            try
            {
                bool result = dal.Delete(OutputInvoiceId);
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
        /// <param name="OutputInvoiceId"></param>
        /// <returns></returns>
        [Route("EditOutputInvoice")]
        [HttpPost]
        public IActionResult EditOutputInvoice(int OutputInvoiceId)
        {
            try
            {
                OutputInvoice result = dal.Edit(OutputInvoiceId);
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
        [Route("UpdateOutputInvoice")]
        [HttpPost]
        public IActionResult UpdateOutputInvoice(OutputInvoice exit)
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
