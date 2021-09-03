using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Set
{
    public class RoleModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色备注
        /// </summary>
        public string RoleRemark { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        public int RoleStatus { get; set; }

        /// <summary>
        /// 上级Id
        /// </summary>
        public int RoleParentId { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string RoleOtherName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime RoleCreatDate { get; set; }
    }
}
