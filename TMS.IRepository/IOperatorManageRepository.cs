using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Set;

namespace TMS.IRepository
{
    public interface IOperatorManageRepository
    {
        /// <summary>
        /// 操作员显示
        /// </summary>
        /// <returns></returns>
        List<OperatorManage> OperatorManageShow();

        /// <summary>
        /// 新增操作员
        /// </summary>
        /// <param name="operatorManage"></param>
        /// <returns></returns>
        bool AddOperatorManage(OperatorManage operatorManage);

        /// <summary>
        /// 根据操作员Id删除操作员
        /// </summary>
        /// <param name="OperatorManageId"></param>
        /// <returns></returns>
        bool DeleteOperator(int OperatorManageId);

        /// <summary>
        /// 反填改操作员
        /// </summary>
        /// <param name="OperatorManageId"></param>
        /// <returns></returns>
        OperatorManage EditOperatorManage(int OperatorManageId);

        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="operatorManage"></param>
        /// <returns></returns>
        bool UpdateOperator(OperatorManage operatorManage);
    }
}
