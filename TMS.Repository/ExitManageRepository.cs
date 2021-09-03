using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Personnel;

namespace TMS.Repository
{
    public class ExitManageRepository: IExitManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<ExitManage> ExitManageShow()
        {
            string sql = $"select * from ExitManage";
            return MySqlDapper.DapperQuery<ExitManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool AddExitManage(ExitManage exit)
        {
            string sql = "insert into ExitManage values(null,@DepartMent_Id,@Position_Id,@UsersInfo_Id,@EManage_Id,@EntryDate,@ExitDate,@ExitCause,@ExitState,@Approver,@ApproveRemark,@ExitCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @DepartMent_Id = exit.DepartMent_Id,
                @Position_Id = exit.Position_Id,
                @UsersInfo_Id = exit.UsersInfo_Id,
                @EManage_Id = exit.EManage_Id,
                @EntryDate = exit.EntryDate,
                @ExitDate = exit.ExitDate,
                @ExitCause = exit.ExitCause,
                @ExitState = exit.ExitState,
                @Approver = exit.Approver,
                @ApproveRemark = exit.ApproveRemark,
                @ExitCreateDate = exit.ExitCreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ExitManageId"></param>
        /// <returns></returns>
        public bool DeleteExitManage(int ExitManageId)
        {
            string sql = "DELETE FROM ExitManage WHERE DepartMentId IN (@ExitManageId)";
            return MySqlDapper.DapperExcute(sql, new { @ExitManageId = ExitManageId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        public ExitManage EditExitManage(int ExitManageId)
        {
            string sql = $"select * from ExitManage where ExitManageId={ExitManageId}";
            return MySqlDapper.DapperQuery<ExitManage>(sql, new { @ExitManageId = ExitManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateExitManage(ExitManage exit)
        {
            string sql = "UPDATE ExitManage SET DepartMent_Id =@DepartMent_Id,Position_Id = @Position_Id,UsersInfo_Id = @UsersInfo_Id,EManage_Id = @EManage_Id,EntryDate =@EntryDate,ExitDate = @ExitDate,ExitCause = @ExitCause,ExitState = @ExitState,Approver =@Approver,ApproveRemark = @ApproveRemark,ExitCreateDate = @ExitCreateDate WHERE ExitManageId = @ExitManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ExitManageId = exit.ExitManageId,
                @DepartMent_Id = exit.DepartMent_Id,
                @Position_Id = exit.Position_Id,
                @UsersInfo_Id = exit.UsersInfo_Id,
                @EManage_Id = exit.EManage_Id,
                @EntryDate = exit.EntryDate,
                @ExitDate = exit.ExitDate,
                @ExitCause = exit.ExitCause,
                @ExitState = exit.ExitState,
                @Approver = exit.Approver,
                @ApproveRemark = exit.ApproveRemark,
                @ExitCreateDate = exit.ExitCreateDate
            });
        }
    }
}
