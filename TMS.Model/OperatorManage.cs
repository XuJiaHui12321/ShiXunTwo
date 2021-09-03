using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Set
{
    /// <summary>
    /// 操作员管理
    /// </summary>
    public class OperatorManage
    {
        /// <summary>
        /// Id
        /// </summary>
        public int OperatorManageId { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string OperatorManageBh { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string OperatorCompanyName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string OperatorPhone { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public int OperatorRole_Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OperatorCreateDate { get; set; }

        /// <summary>
        /// 状态（1.启用 0禁用）
        /// </summary>
        public int OperatorState { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string OperatorPwd { get; set; }
    }
}
