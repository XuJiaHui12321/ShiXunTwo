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
    /// 物资采购--审批
    /// </summary>
    public class PurchaseRepository: IPurchaseRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Purchase> PurchaseShow()
        {
            string sql = $"select * from Purchase";
            return MySqlDapper.DapperQuery<Purchase>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public bool AddPurchase(Purchase purchase)
        {
            string sql = "insert into Purchase values(null,PurchaseName = @PurchaseName,PurchaseType = @PurchaseType,PurchaseTexture = @PurchaseTexture,PurchaseSpecification = @PurchaseSpecification,PurchaseAddress = @PurchaseAddress,PurchaseNum = @PurchaseNum,PurchaseUseRemark = @PurchaseUseRemark,proposer = @proposer,PayDate = @PayDate,PayMentRemark = @PayMentRemark,CreateDate = @CreateDate,OwnerContractState = @OwnerContractState,Approver = @Approver,ApproveRemark = @ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PurchaseName = purchase.PurchaseName,
                @PurchaseType = purchase.PurchaseType,
                @PurchaseTexture = purchase.PurchaseTexture,
                @PurchaseSpecification = purchase.PurchaseSpecification,
                @PurchaseAddress = purchase.PurchaseAddress,
                @PurchaseNum = purchase.PurchaseNum,
                @PurchaseUseRemark = purchase.PurchaseUseRemark,
                @proposer = purchase.proposer,
                @PayDate = purchase.PayDate,
                @PayMentRemark = purchase.PayMentRemark,
                @CreateDate = purchase.CreateDate,
                @OwnerContractState = purchase.OwnerContractState,
                @Approver = purchase.Approver,
                @ApproveRemark = purchase.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        public bool DeletePurchase(int PurchaseId)
        {
            string sql = "DELETE FROM Purchase WHERE PurchaseId IN (@PurchaseId)";
            return MySqlDapper.DapperExcute(sql, new { @PurchaseId = PurchaseId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        public Purchase EditPurchase(int PurchaseId)
        {
            string sql = $"select * from Purchase where PurchaseId={PurchaseId}";
            return MySqlDapper.DapperQuery<Purchase>(sql, new { @PurchaseId = PurchaseId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns></returns>
        public bool UpdatePurchase(Purchase purchase)
        {
            string sql = "UPDATE Purchase SET PurchaseName = @PurchaseName,PurchaseType = @PurchaseType,PurchaseTexture = @PurchaseTexture,PurchaseSpecification = @PurchaseSpecification,PurchaseAddress = @PurchaseAddress,PurchaseNum = @PurchaseNum,PurchaseUseRemark = @PurchaseUseRemark,proposer = @proposer,PayDate = @PayDate,PayMentRemark = @PayMentRemark,CreateDate = @CreateDate,OwnerContractState = @OwnerContractState,Approver = @Approver,ApproveRemark = @ApproveRemark  WHERE PurchaseId  =@PurchaseId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PurchaseId = purchase.PurchaseId,
                @PurchaseName = purchase.PurchaseName,
                @PurchaseType = purchase.PurchaseType,
                @PurchaseTexture = purchase.PurchaseTexture,
                @PurchaseSpecification = purchase.PurchaseSpecification,
                @PurchaseAddress = purchase.PurchaseAddress,
                @PurchaseNum = purchase.PurchaseNum,
                @PurchaseUseRemark = purchase.PurchaseUseRemark,
                @proposer = purchase.proposer,
                @PayDate = purchase.PayDate,
                @PayMentRemark = purchase.PayMentRemark,
                @CreateDate = purchase.CreateDate,
                @OwnerContractState = purchase.OwnerContractState,
                @Approver = purchase.Approver,
                @ApproveRemark = purchase.ApproveRemark
            });
        }
    }
}
