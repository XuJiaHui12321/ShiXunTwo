using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Set
{
    public class DepartMent
    {
        /// <summary>
        /// Id
        /// </summary>
        public int DepartMentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartMentName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DepartMentCreateDate { get; set; }

        /// <summary>
        /// 上级部门
        /// </summary>
        public int DepartMentParentId { get; set; }
    }
}
