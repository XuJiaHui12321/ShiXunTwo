using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    /// <summary>
    /// 物资领用
    /// </summary>
    public class GoodReceive
    {
        public int          GoodReceiveId            { get; set; }
        public string       GoodReceiveTitle         { get; set; }
        public string       UseRemark                { get; set; }
        public string       UserName                 { get; set; }
        public DateTime     UseDate                  { get; set; }
        public string       GoodReceiveRemark        { get; set; }
        public int          UseGoods_Id              { get; set; }
        public string       PurchaseType             { get; set; }
        public string       PurchaseTexture          { get; set; }
        public string       PurchaseSpecification    { get; set; }
        public string       PurchaseAddress         { get; set; }
        public int          PurchaseNum             { get; set; }
        public DateTime     CreateDate              { get; set; }
        public string       ExitState               { get; set; }
        public string       Approver                { get; set; }
        public string       ApproveRemark           { get; set; }
    }
}
