using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model;

namespace TMS.Repository
{
    /// <summary>
    /// 应付费用管理
    /// </summary>
    public class AccountsPayableRepository: IAccountsPayableRepository
    {

        

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<AccountsPayable> AccountsPayableShow()
        {
            string sql = $"select * from AccountsPayable";
            return MySqlDapper.DapperQuery<AccountsPayable>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool AddAccountsPayable(AccountsPayable exit)
        {
            string sql = "insert into AccountsPayable values(null, @AccountsPayableBh,@AccountsPayableCompany,@PayType,@Tonnage,@UnitPrice,@Price,@BusinessDate,@Principal,@ReceivableRemark,@CreateDate,@CreateState,@CreateName,@ReceivableDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @AccountsPayableBh = exit.AccountsPayableBh,
                @AccountsPayableCompany = exit.AccountsPayableCompany,
                @PayType = exit.PayType,
                @Tonnage = exit.Tonnage,
                @UnitPrice = exit.UnitPrice,
                @Price = exit.Price,
                @BusinessDate = exit.BusinessDate,
                @Principal = exit.Principal,
                @ReceivableRemark = exit.ReceivableRemark,
                @CreateDate = exit.CreateDate,
                @CreateState = exit.CreateState,
                @CreateName = exit.CreateName,
                @ReceivableDate = exit.ReceivableDate
            });

           
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="AccountsPayableId"></param>
        /// <returns></returns>
        public bool DeleteAccountsPayable(int AccountsPayableId)
        {
            string sql = "DELETE FROM AccountsPayable WHERE DepartMentId IN (@AccountsPayableId)";
            return MySqlDapper.DapperExcute(sql, new { @AccountsPayableId = AccountsPayableId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        public AccountsPayable EditAccountsPayable(int AccountsPayableId)
        {
            string sql = $"select * from AccountsPayable where AccountsPayableId={AccountsPayableId}";
            return MySqlDapper.DapperQuery<AccountsPayable>(sql, new { @AccountsPayableId = AccountsPayableId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateAccountsPayable(AccountsPayable exit)
        {
            string sql = "UPDATE AccountsPayable SET AccountsPayableId = @AccountsPayableId,AccountsPayableBh = @AccountsPayableBh,AccountsPayableCompany = @AccountsPayableCompany,PayType = @PayType,Tonnage = @Tonnage,UnitPrice = @UnitPrice,Price = @Price,BusinessDate = @BusinessDate,Principal = @Principal,ReceivableRemark = @ReceivableRemark,CreateDate = @CreateDate,CreateState = @CreateState,CreateName = @CreateName,ReceivableDate = @ReceivableDate WHERE AccountsPayableId =@AccountsPayableId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @AccountsPayableId = exit.AccountsPayableId,
                @AccountsPayableBh = exit.AccountsPayableBh,
                @AccountsPayableCompany = exit.AccountsPayableCompany,
                @PayType = exit.PayType,
                @Tonnage = exit.Tonnage,
                @UnitPrice = exit.UnitPrice,
                @Price = exit.Price,
                @BusinessDate = exit.BusinessDate,
                @Principal = exit.Principal,
                @ReceivableRemark = exit.ReceivableRemark,
                @CreateDate = exit.CreateDate,
                @CreateState = exit.CreateState,
                @CreateName = exit.CreateName,
                @ReceivableDate = exit.ReceivableDate
            });
        }
    }
}
