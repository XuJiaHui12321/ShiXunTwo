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
    /// 付款管理
    /// </summary>
    public class PayMentManageRepository:IPayMentManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<PayMentManage> Show()
        {
            string sql = $"select * from PayMentManage";
            return MySqlDapper.DapperQuery<PayMentManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Add(PayMentManage pay)
        {
            string sql = "insert into PayMentManage values(null,PayMentManageTitle=@PayMentManageTitle,UseRemark = @UseRemark,PayPrice = @PayPrice,PayType = @PayType,PayCompany = @PayCompany,OpenBank = @OpenBank,BankAccount = @BankAccount,Principal = @Principal,PayDate = @PayDate,PayMentRemark = @PayMentRemark,PayMentText = @PayMentText,CreateDate = @CreateDate,OwnerContractState = @OwnerContractState,Approver = @Approver,ApproveRemark = @ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PayMentManageId = pay.PayMentManageId,
                @PayMentManageTitle = pay.PayMentManageTitle,
                @UseRemark = pay.UseRemark,
                @PayPrice = pay.PayPrice,
                @PayType = pay.PayType,
                @PayCompany = pay.PayCompany,
                @OpenBank = pay.OpenBank,
                @BankAccount = pay.BankAccount,
                @Principal = pay.Principal,
                @PayDate = pay.PayDate,
                @PayMentRemark = pay.PayMentRemark,
                @PayMentText = pay.PayMentText,
                @CreateDate = pay.CreateDate,
                @OwnerContractState = pay.OwnerContractState,
                @Approver = pay.Approver,
                @ApproveRemark = pay.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PayMentManageId"></param>
        /// <returns></returns>
        public bool Delete(int PayMentManageId)
        {
            string sql = "DELETE FROM PayMentManage WHERE PayMentManageId IN (@PayMentManageId)";
            return MySqlDapper.DapperExcute(sql, new { @PayMentManageId = PayMentManageId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="PayMentManageId"></param>
        /// <returns></returns>
        public PayMentManage Edit(int PayMentManageId)
        {
            string sql = $"select * from PayMentManage where PayMentManageId={PayMentManageId}";
            return MySqlDapper.DapperQuery<PayMentManage>(sql, new { @PayMentManageId = PayMentManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(PayMentManage pay)
        {
            string sql = "UPDATE PayMentManage SET PayMentManageId=@PayMentManageId,PayMentManageTitle=@PayMentManageTitle,UseRemark = @UseRemark,PayPrice = @PayPrice,PayType = @PayType,PayCompany = @PayCompany,OpenBank = @OpenBank,BankAccount = @BankAccount,Principal = @Principal,PayDate = @PayDate,PayMentRemark = @PayMentRemark,PayMentText = @PayMentText,CreateDate = @CreateDate,OwnerContractState = @OwnerContractState,Approver = @Approver,ApproveRemark = @ApproveRemark  WHERE PayMentManageId  =@PayMentManageId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PayMentManageId=pay.PayMentManageId,    
                @PayMentManageTitle=pay.PayMentManageTitle, 
                @UseRemark=pay.UseRemark,   						
                @PayPrice=pay.PayPrice,    						
                @PayType=pay.PayType,    						
                @PayCompany=pay.PayCompany,   				
                @OpenBank=pay.OpenBank,   						
                @BankAccount=pay.BankAccount,   				
                @Principal=pay.Principal,  						
                @PayDate=pay.PayDate,   							
                @PayMentRemark=pay.PayMentRemark, 				
                @PayMentText=pay.PayMentText,    		
                @CreateDate=pay.CreateDate,  				
                @OwnerContractState =pay.OwnerContractState, 
                @Approver=pay.Approver,    						
                @ApproveRemark= pay.ApproveRemark
            });
        }
    }
}

