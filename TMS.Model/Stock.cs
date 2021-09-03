using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 入库管理
    /// </summary>
    public class Stock
    {
        public int          StockId             { get; set; }
        public string       StockName           { get; set; }
        public string       StockType           { get; set; }
        public string       StockTexture        { get; set; }
        public string       StockSpecification  { get; set; }
        public string       StockAddress        { get; set; }
        public int          StockNum            { get; set; }
        public decimal      StockPrice          { get; set; }
        public string       PayType             { get; set; }
        public DateTime     StockCreateDate     { get; set; }
        public decimal      StockTotalPrice     { get; set; }
        public string       Principal           { get; set; }
        public string       PayMentRemark       { get; set; }
    }
}
