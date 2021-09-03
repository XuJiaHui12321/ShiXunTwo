using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.GoodsMaterial;

namespace TMS.Repository
{
    public class ReceivableRepository: IReceivableRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Receivable> ReceivableShow()
        {
            string sql = $"select * from Receivable";
            return MySqlDapper.DapperQuery<Receivable>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public bool AddReceivable(Receivable rece)
        {
            string sql = "insert into Receivable values(null,@ReceivableBh,@ReceivableCompany,@PayType,@Tonnage,@UnitPrice,@Price,@BusinessDate,@Principal,@ReceivableRemark,@ContractChange,@ContractText,@CreateDate,@CreateState,@CreateName,@ReceivableDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ReceivableBh = rece.ReceivableBh,
                @ReceivableCompany = rece.ReceivableCompany,
                @PayType = rece.PayType,
                @Tonnage = rece.Tonnage,
                @UnitPrice = rece.UnitPrice,
                @Price = rece.Price,
                @BusinessDate = rece.BusinessDate,
                @Principal = rece.Principal,
                @ReceivableRemark = rece.ReceivableRemark,
                @ContractChange = rece.ContractChange,
                @ContractText = rece.ContractText,
                @CreateDate = rece.CreateDate,
                @CreateState = rece.CreateState,
                @CreateName = rece.CreateName,
                @ReceivableDate = rece.ReceivableDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ReceivableId"></param>
        /// <returns></returns>
        public bool DeleteReceivable(int ReceivableId)
        {
            string sql = "DELETE FROM Receivable WHERE ReceivableId IN (@ReceivableId)";
            return MySqlDapper.DapperExcute(sql, new { @ReceivableId = ReceivableId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ReceivableId"></param>
        /// <returns></returns>
        public Receivable EditReceivable(int ReceivableId)
        {
            string sql = $"select * from Receivable where ReceivableId={ReceivableId}";
            return MySqlDapper.DapperQuery<Receivable>(sql, new { @ReceivableId = ReceivableId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="rece"></param>
        /// <returns></returns>
        public bool UpdateReceivable(Receivable rece)
        {
            string sql = "UPDATE CarrierContract SET ReceivableBh =@ReceivableBh,ReceivableCompany = @ReceivableCompany,PayType = @PayType,Tonnage = @Tonnage,UnitPrice = @UnitPrice,Price = @Price,BusinessDate = @BusinessDate,Principal = @Principal,ReceivableRemark = @ReceivableRemark,ContractChange = @ContractChange,ContractText = @ContractText,CreateDate = @CreateDate,CreateState = @CreateState,CreateName = @CreateName,ReceivableDate = @ReceivableDate WHERE ReceivableId =@ReceivableId;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ReceivableId = rece.ReceivableId,
                @ReceivableBh = rece.ReceivableBh,
                @ReceivableCompany = rece.ReceivableCompany,
                @PayType = rece.PayType,
                @Tonnage = rece.Tonnage,
                @UnitPrice = rece.UnitPrice,
                @Price = rece.Price,
                @BusinessDate = rece.BusinessDate,
                @Principal = rece.Principal,
                @ReceivableRemark = rece.ReceivableRemark,
                @ContractChange = rece.ContractChange,
                @ContractText = rece.ContractText,
                @CreateDate = rece.CreateDate,
                @CreateState = rece.CreateState,
                @CreateName = rece.CreateName,
                @ReceivableDate = rece.ReceivableDate
            });
        }
    }
}
