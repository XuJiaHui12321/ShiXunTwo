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
    public class OutputInvoiceRepository: IOutputInvoiceRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OutputInvoice> Show()
        {
            string sql = $"select * from OutputInvoice";
            return MySqlDapper.DapperQuery<OutputInvoice>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Add(OutputInvoice output)
        {
            string sql = "insert into OutputInvoice values(null,OutputInvoiceBh = @OutputInvoiceBh,OutputInvoiceCompany = @OutputInvoiceCompany,OutputInvoiceType = @OutputInvoiceType,OutputInvoicePrice = @OutputInvoicePrice,TaxRate = @TaxRate,TaxPrice = @TaxPrice,ReceiptsInvoiceDate = @ReceiptsInvoiceDate,ReceivableRemark = @ReceivableRemark,Principal = @Principal,OutputCreateDate = @OutputCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OutputInvoiceBh = output.OutputInvoiceBh,
                @OutputInvoiceCompany = output.OutputInvoiceCompany,
                @OutputInvoiceType = output.OutputInvoiceType,
                @OutputInvoicePrice = output.OutputInvoicePrice,
                @TaxRate = output.TaxRate,
                @TaxPrice = output.TaxPrice,
                @ReceiptsInvoiceDate = output.ReceiptsInvoiceDate,
                @ReceivableRemark = output.ReceivableRemark,
                @Principal = output.Principal,
                @OutputCreateDate = output.OutputCreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OutputInvoiceId"></param>
        /// <returns></returns>
        public bool Delete(int OutputInvoiceId)
        {
            string sql = "DELETE FROM OutputInvoice WHERE OutputInvoiceId IN (@OutputInvoiceId)";
            return MySqlDapper.DapperExcute(sql, new { @OutputInvoiceId = OutputInvoiceId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="OutputInvoiceId"></param>
        /// <returns></returns>
        public OutputInvoice Edit(int OutputInvoiceId)
        {
            string sql = $"select * from OutputInvoice where OutputInvoiceId={OutputInvoiceId}";
            return MySqlDapper.DapperQuery<OutputInvoice>(sql, new { @OutputInvoiceId = OutputInvoiceId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(OutputInvoice output)
        {
            string sql = "UPDATE OutputInvoice SET OutputInvoiceId= @OutputInvoiceId,OutputInvoiceBh = @OutputInvoiceBh,OutputInvoiceCompany = @OutputInvoiceCompany,OutputInvoiceType = @OutputInvoiceType,OutputInvoicePrice = @OutputInvoicePrice,TaxRate = @TaxRate,TaxPrice = @TaxPrice,ReceiptsInvoiceDate = @ReceiptsInvoiceDate,ReceivableRemark = @ReceivableRemark,Principal = @Principal,OutputCreateDate = @OutputCreateDate  WHERE OutputInvoiceId  =@OutputInvoiceId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OutputInvoiceId= output.OutputInvoiceId,
                @OutputInvoiceBh = output.OutputInvoiceBh,
                @OutputInvoiceCompany=output.OutputInvoiceCompany,
                @OutputInvoiceType = output.OutputInvoiceType,
                @OutputInvoicePrice = output.OutputInvoicePrice,
                @TaxRate = output.TaxRate,
                @TaxPrice = output.TaxPrice,
                @ReceiptsInvoiceDate = output.ReceiptsInvoiceDate, 
                @ReceivableRemark= output.ReceivableRemark,
                @Principal = output.Principal,
                @OutputCreateDate = output.OutputCreateDate
            });
        }
    }
}
