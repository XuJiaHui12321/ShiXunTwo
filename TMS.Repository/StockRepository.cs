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
    public class StockRepository:IStockRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Stock> Show()
        {
            string sql = $"select * from Stock";
            return MySqlDapper.DapperQuery<Stock>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Add(Stock stock)
        {
            string sql = "insert into Stock values(null,StockName=@StockName,StockType=@StockType,StockTexture = @StockTexture,StockSpecification =@StockSpecification,StockAddress = @StockAddress,StockNum = @StockNum, StockPrice = @StockPrice,PayType =@PayType,StockCreateDate=@StockCreateDate,StockTotalPrice=@StockTotalPrice,Principal=@Principal,PayMentRemark = @PayMentRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {        
                @StockName= stock.StockName,        
                @StockType= stock.StockType,         
                @StockTexture= stock.StockTexture,      
                @StockSpecification=stock.StockSpecification,
                @StockAddress = stock.StockAddress,      
                @StockNum = stock.StockNum,          
                @StockPrice= stock.StockPrice,        
                @PayType= stock.PayType,           
                @StockCreateDate= stock.StockCreateDate,   
                @StockTotalPrice= stock.StockTotalPrice,   
                @Principal= stock.Principal,         
                @PayMentRemark = stock.PayMentRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="StockId"></param>
        /// <returns></returns>
        public bool Delete(int StockId)
        {
            string sql = "DELETE FROM Stock WHERE StockId IN (@StockId)";
            return MySqlDapper.DapperExcute(sql, new { @StockId = StockId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="StockId"></param>
        /// <returns></returns>
        public Stock Edit(int StockId)
        {
            string sql = $"select * from Stock where StockId={StockId}";
            return MySqlDapper.DapperQuery<Stock>(sql, new { @StockId = StockId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(Stock stock)
        {
            string sql = "UPDATE Stock SET StockId = @StockId,StockName = @StockName,StockType = @StockType,StockTexture = @StockTexture,StockSpecification = @StockSpecification,StockAddress = @StockAddress,StockNum = @StockNum, StockPrice = @StockPrice,PayType = @PayType,StockCreateDate = @StockCreateDate,StockTotalPrice = @StockTotalPrice,Principal = @Principal,PayMentRemark = @PayMentRemark  WHERE StockId  =@StockId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @StockId = stock.StockId,
                @StockName = stock.StockName,
                @StockType = stock.StockType,
                @StockTexture = stock.StockTexture,
                @StockSpecification = stock.StockSpecification,
                @StockAddress = stock.StockAddress,
                @StockNum = stock.StockNum,
                @StockPrice = stock.StockPrice,
                @PayType = stock.PayType,
                @StockCreateDate = stock.StockCreateDate,
                @StockTotalPrice = stock.StockTotalPrice,
                @Principal = stock.Principal,
                @PayMentRemark = stock.PayMentRemark
            });
        }
    }
}
