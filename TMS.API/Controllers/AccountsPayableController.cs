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
    /// 应付费用管理
    /// </summary>
    [ApiController]
    [Route("AccountsPayableApi")]
    public class AccountsPayableController : Controller
    {
        private IAccountsPayableRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public AccountsPayableController(IAccountsPayableRepository _dal)
        {
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AccountsPayableIndex")]
        public IActionResult AccountsPayableIndex()
        {
            try
            {
                List<AccountsPayable> list = dal.AccountsPayableShow();
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
        [Route("AddAccountsPayable")]
        public IActionResult AddAccountsPayable(AccountsPayable receivable)
        {
            try
            {
                bool result = dal.AddAccountsPayable(receivable);
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
        /// <param name="AccountsPayableId"></param>
        /// <returns></returns>
        [Route("AccountsPayableDel")]
        [HttpPost]
        public IActionResult AccountsPayableDel(int AccountsPayableId)
        {
            try
            {
                bool result = dal.DeleteAccountsPayable(AccountsPayableId);
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
        /// <param name="AccountsPayableId"></param>
        /// <returns></returns>
        [Route("EditAccountsPayable")]
        [HttpPost]
        public IActionResult EditAccountsPayable(int AccountsPayableId)
        {
            try
            {
                AccountsPayable result = dal.EditAccountsPayable(AccountsPayableId);
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
        [Route("UpdateAccountsPayable")]
        [HttpPost]
        public IActionResult UpdateAccountsPayable(AccountsPayable exit)
        {
            try
            {
                bool result = dal.UpdateAccountsPayable(exit);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }
    }
}
