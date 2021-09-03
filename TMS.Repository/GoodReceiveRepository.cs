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
    public class GoodReceiveRepository: IGoodReceiveRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<GoodReceive> Show()
        {
            string sql = $"select * from GoodReceive";
            return MySqlDapper.DapperQuery<GoodReceive>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Add(GoodReceive good)
        {
            string sql = "insert into GoodReceive values(null,GoodReceiveTitle = @GoodReceiveTitle,UseRemark = @UseRemark,UserName = @UserName,UseDate = @UseDate,GoodReceiveRemark = @GoodReceiveRemark,UseGoods_Id = @UseGoods_Id,PurchaseType = @PurchaseType,PurchaseTexture = @PurchaseTexture,PurchaseSpecification = @PurchaseSpecification,PurchaseAddress = @PurchaseAddress,PurchaseNum = @PurchaseNum,CreateDate = @CreateDate,ExitState = @ExitState,Approver = @Approver,ApproveRemark = @ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @GoodReceiveId = good.GoodReceiveId,
                @GoodReceiveTitle = good.GoodReceiveTitle,
                @UseRemark = good.UseRemark,
                @UserName = good.UserName,
                @UseDate = good.UseDate,
                @GoodReceiveRemark = good.GoodReceiveRemark,
                @UseGoods_Id = good.UseGoods_Id,
                @PurchaseType = good.PurchaseType,
                @PurchaseTexture = good.PurchaseTexture,
                @PurchaseSpecification = good.PurchaseSpecification,
                @PurchaseAddress = good.PurchaseAddress,
                @PurchaseNum = good.PurchaseNum,
                @CreateDate = good.CreateDate,
                @ExitState = good.ExitState,
                @Approver = good.Approver,
                @ApproveRemark = good.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="GoodReceiveId"></param>
        /// <returns></returns>
        public bool Delete(int GoodReceiveId)
        {
            string sql = "DELETE FROM GoodReceive WHERE GoodReceiveId IN (@GoodReceiveId)";
            return MySqlDapper.DapperExcute(sql, new { @GoodReceiveId = GoodReceiveId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="GoodReceiveId"></param>
        /// <returns></returns>
        public GoodReceive Edit(int GoodReceiveId)
        {
            string sql = $"select * from GoodReceive where GoodReceiveId={GoodReceiveId}";
            return MySqlDapper.DapperQuery<GoodReceive>(sql, new { @GoodReceiveId = GoodReceiveId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(GoodReceive good)
        {
            string sql = "UPDATE GoodReceive SET GoodReceiveId=@GoodReceiveId,GoodReceiveTitle = @GoodReceiveTitle,UseRemark = @UseRemark,UserName = @UserName,UseDate = @UseDate,GoodReceiveRemark = @GoodReceiveRemark,UseGoods_Id = @UseGoods_Id,PurchaseType = @PurchaseType,PurchaseTexture = @PurchaseTexture,PurchaseSpecification = @PurchaseSpecification,PurchaseAddress = @PurchaseAddress,PurchaseNum = @PurchaseNum,CreateDate = @CreateDate,ExitState = @ExitState,Approver = @Approver,ApproveRemark = @ApproveRemark  WHERE GoodReceiveId=@GoodReceiveId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @GoodReceiveId=good.GoodReceiveId,         
                @GoodReceiveTitle=good.GoodReceiveTitle,      
                @UseRemark=good.UseRemark,             
                @UserName=good.UserName,              
                @UseDate=good.UseDate,               
                @GoodReceiveRemark=good.GoodReceiveRemark,     
                @UseGoods_Id=good.UseGoods_Id,           
                @PurchaseType=good.PurchaseType,          
                @PurchaseTexture=good.PurchaseTexture,       
                @PurchaseSpecification=good.PurchaseSpecification, 
                @PurchaseAddress=good.PurchaseAddress,       
                @PurchaseNum=good.PurchaseNum,          
                @CreateDate=good.CreateDate,           
                @ExitState=good.ExitState,             
                @Approver=good.Approver,              
                @ApproveRemark=good. ApproveRemark
            });
        }
    }
}

