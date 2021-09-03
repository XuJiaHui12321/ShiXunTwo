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
    public class RegularManageRepository: IRegularManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<RegularManage> RegularManageShow()
        {
            string sql = $"select * from RegularManage";
            return MySqlDapper.DapperQuery<RegularManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool AddRegularManage(RegularManage regular)
        {
            string sql = "insert into RegularManage values(null,@DepartMent_Id,@Position_Id,@UsersInfo_Id,@EManage_Id,@EntryDate,@WorkSummary,@WorkOpinion,@ExitState,@Approver,@ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @DepartMent_Id = regular.DepartMent_Id,
                @Position_Id = regular.Position_Id,
                @UsersInfo_Id = regular.UsersInfo_Id,
                @EManage_Id = regular.EManage_Id,
                @EntryDate = regular.EntryDate,
                @WorkSummary = regular.WorkSummary,
                @WorkOpinion = regular.WorkOpinion,
                @ExitState = regular.ExitState,
                @Approver = regular.Approver,
                @ApproveRemark = regular.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="RegularManageId"></param>
        /// <returns></returns>
        public bool DeleteRegularManage(int RegularManageId)
        {
            string sql = "DELETE FROM RegularManage WHERE RegularManageId IN (@RegularManageId)";
            return MySqlDapper.DapperExcute(sql, new { @RegularManageId = RegularManageId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="RegularManageId"></param>
        /// <returns></returns>
        public RegularManage EditRegularManage(int RegularManageId)
        {
            string sql = $"select * from RegularManage where RegularManageId={RegularManageId}";
            return MySqlDapper.DapperQuery<RegularManage>(sql, new { @RegularManageId = RegularManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="regular"></param>
        /// <returns></returns>
        public bool UpdateRegularManage(RegularManage regular)
        {
            string sql = "UPDATE RegularManage SET RegularManageId = @RegularManageId,DepartMent_Id = @DepartMent_Id,Position_Id = @Position_Id,UsersInfo_Id = @UsersInfo_Id,EManage_Id = @EManage_Id,EntryDate = @EntryDate,WorkSummary = @WorkSummary,WorkOpinion =@WorkOpinion,ExitState = @ExitState,Approver = @Approver,ApproveRemark = @ApproveRemark WHERE RegularManageId = @RegularManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @RegularManageId = regular.RegularManageId,
                @DepartMent_Id = regular.DepartMent_Id,
                @Position_Id = regular.Position_Id,
                @UsersInfo_Id = regular.UsersInfo_Id,
                @EManage_Id = regular.EManage_Id,
                @EntryDate = regular.EntryDate,
                @WorkSummary = regular.WorkSummary,
                @WorkOpinion = regular.WorkOpinion,
                @ExitState = regular.ExitState,
                @Approver = regular.Approver,
                @ApproveRemark = regular.ApproveRemark
            });
        }
    }
}
