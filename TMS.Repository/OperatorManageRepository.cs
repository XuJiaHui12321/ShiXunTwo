using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Set;

namespace TMS.Repository
{
    public class OperatorManageRepository: IOperatorManageRepository
    {
        /// <summary>
        /// 操作员显示
        /// </summary>
        /// <returns></returns>
        public List<OperatorManage> OperatorManageShow()
        {
            string sql = $"select * from OperatorManage";
            return MySqlDapper.DapperQuery<OperatorManage>(sql, "");
        }

        /// <summary>
        /// 新增操作员
        /// </summary>
        /// <param name="operatorManage"></param>
        /// <returns></returns>
        public bool AddOperatorManage(OperatorManage operatorManage)
        {
            string sql = "insert into OperatorManage values(null,@OperatorManageBh,@OperatorName,@OperatorCompanyName,@OperatorPhone,@OperatorRole_Id,@OperatorCreateDate,@OperatorState,@OperatorPwd)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OperatorManageBh = operatorManage.OperatorManageBh,
                @OperatorName = operatorManage.OperatorName,
                @OperatorCompanyName = operatorManage.OperatorCompanyName,
                @OperatorPhone = operatorManage.OperatorPhone,
                @OperatorRole_Id = operatorManage.OperatorRole_Id,
                @OperatorCreateDate = operatorManage.OperatorCreateDate,
                @OperatorState = operatorManage.OperatorState,
                @OperatorPwd = operatorManage.OperatorPwd
            });
        }


        /// <summary>
        /// 根据操作员Id删除操作员
        /// </summary>
        /// <param name="OperatorManageId"></param>
        /// <returns></returns>
        public bool DeleteOperator(int OperatorManageId)
        {
            string sql = "DELETE FROM OperatorManage WHERE OperatorManageId IN (@OperatorManageId)";
            return MySqlDapper.DapperExcute(sql, new { @OperatorManageId = OperatorManageId });
        }


        /// <summary>
        /// 反填改操作员
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        public OperatorManage EditOperatorManage(int OperatorManageId)
        {
            string sql = $"select * from OperatorManage where OperatorManageId={OperatorManageId}";
            return MySqlDapper.DapperQuery<OperatorManage>(sql, new { @OperatorManageId = OperatorManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdateOperator(OperatorManage operatorManage)
        {
            string sql = "UPDATE OperatorManage SET OperatorManageBh = @OperatorManageBh,OperatorCompanyName = @OperatorCompanyName,OperatorName =@OperatorName,OperatorRole_Id = @OperatorRole_Id,OperatorPwd = @OperatorPwd WHERE OperatorManageId=@OperatorManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OperatorManageId = operatorManage.OperatorManageId,
                @OperatorManageBh = operatorManage.OperatorManageBh,
                @OperatorCompanyName = operatorManage.OperatorCompanyName,
                @OperatorName = operatorManage.OperatorName,
                @OperatorRole_Id = operatorManage.OperatorRole_Id,
                @OperatorPwd = operatorManage.OperatorPwd
            });
        }
    }
}
