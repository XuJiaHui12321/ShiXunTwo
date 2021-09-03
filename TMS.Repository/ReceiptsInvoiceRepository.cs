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
    /// 进项发票管理
    /// </summary>
    public class ReceiptsInvoiceRepository: IReceiptsInvoiceRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<ReceiptsInvoice> Show()
        {
            string sql = $"select * from ReceiptsInvoice";
            return MySqlDapper.DapperQuery<ReceiptsInvoice>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Add(ReceiptsInvoice receipts)
        {
            string sql = "insert into ReceiptsInvoice values(null,ReceiptsInvoiceBh = @ReceiptsInvoiceBh,ReceiptsInvoiceCompany = @ReceiptsInvoiceCompany,ReceiptsInvoiceType = @ReceiptsInvoiceType,TaxRate = @TaxRate,TaxPrice = @TaxPrice,ReceiptsInvoiceDate = @ReceiptsInvoiceDate,ReceivableRemark = @ReceivableRemark,Principal = @Principal,CreateDate = @CreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ReceiptsInvoiceBh = receipts.ReceiptsInvoiceBh,
                @ReceiptsInvoiceCompany = receipts.ReceiptsInvoiceCompany,
                @ReceiptsInvoiceType = receipts.ReceiptsInvoiceType,
                @TaxRate = receipts.TaxRate,
                @TaxPrice = receipts.TaxPrice,
                @ReceiptsInvoiceDate = receipts.ReceiptsInvoiceDate,
                @ReceivableRemark = receipts.ReceivableRemark,
                @Principal = receipts.Principal,
                @CreateDate = receipts.CreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ReceiptsInvoiceId"></param>
        /// <returns></returns>
        public bool Delete(int ReceiptsInvoiceId)
        {
            string sql = "DELETE FROM ReceiptsInvoice WHERE ReceiptsInvoiceId IN (@ReceiptsInvoiceId)";
            return MySqlDapper.DapperExcute(sql, new { @ReceiptsInvoiceId = ReceiptsInvoiceId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ReceiptsInvoiceId"></param>
        /// <returns></returns>
        public ReceiptsInvoice Edit(int ReceiptsInvoiceId)
        {
            string sql = $"select * from ReceiptsInvoice where ReceiptsInvoiceId={ReceiptsInvoiceId}";
            return MySqlDapper.DapperQuery<ReceiptsInvoice>(sql, new { @ReceiptsInvoiceId = ReceiptsInvoiceId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(ReceiptsInvoice receipts)
        {
            string sql = "UPDATE ReceiptsInvoice SET ReceiptsInvoiceId=@ReceiptsInvoiceId,ReceiptsInvoiceBh = @ReceiptsInvoiceBh,ReceiptsInvoiceCompany = @ReceiptsInvoiceCompany,ReceiptsInvoiceType = @ReceiptsInvoiceType,TaxRate = @TaxRate,TaxPrice = @TaxPrice,ReceiptsInvoiceDate = @ReceiptsInvoiceDate,ReceivableRemark = @ReceivableRemark,Principal = @Principal,CreateDate = @CreateDate  WHERE ReceiptsInvoiceId  =@ReceiptsInvoiceId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                ReceiptsInvoiceId=receipts.ReceiptsInvoiceId,      
                ReceiptsInvoiceBh=receipts.ReceiptsInvoiceBh,      
                ReceiptsInvoiceCompany= receipts.ReceiptsInvoiceCompany, 
                ReceiptsInvoiceType=receipts.ReceiptsInvoiceType,    
                TaxRate=receipts.TaxRate, 								
                TaxPrice =receipts.TaxPrice, 							
                ReceiptsInvoiceDate =receipts.ReceiptsInvoiceDate,   	
                ReceivableRemark=receipts.ReceivableRemark,  			
                Principal= receipts.Principal,
                CreateDate = receipts.CreateDate
            });
        }
    }
}
