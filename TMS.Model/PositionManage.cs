using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Set
{
    public class PositionManage
    {
        /// <summary>
        /// 职位Id
        /// </summary>
        public int PositionManageId { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public int PositionParentId { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime PositionCreateDate { get; set; }
    }
}
