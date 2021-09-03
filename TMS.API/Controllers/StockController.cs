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
    /// 入库管理
    /// </summary>
    [ApiController]
    [Route("StockApi")]
    public class StockController : Controller
    {
        private IStockRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public StockController(IStockRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("StockIndex")]
        public IActionResult StockIndex()
        {
            try
            {
                List<Stock> list = dal.Show();
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
        [Route("AddStock")]
        public IActionResult AddStock(Stock receivable)
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
        /// <param name="StockId"></param>
        /// <returns></returns>
        [Route("StockDel")]
        [HttpPost]
        public IActionResult StockDel(int StockId)
        {
            try
            {
                bool result = dal.Delete(StockId);
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
        /// <param name="StockId"></param>
        /// <returns></returns>
        [Route("EditStock")]
        [HttpPost]
        public IActionResult EditStock(int StockId)
        {
            try
            {
                Stock result = dal.Edit(StockId);
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
        [Route("UpdateStock")]
        [HttpPost]
        public IActionResult UpdateStock(Stock exit)
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
