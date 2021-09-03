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
    public class UsersInfoRepository: IUsersInfoRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<UsersInfo> UsersInfoShow()
        {
            string sql = $"select a.UsersName,a.UsersSex,b.DepartMentName,c.PositionName,a.UsersPhone,a.UsersSchool,a.UsersMajor,a.UsersAddress,a.StartCompanyDate,a.WorkAge,d.UsersTypeName,a.UsersState,a.UsersCreateDate from usersinfo a inner join DepartMent b on a.DepartMent_Id = b.DepartMentId inner join PositionManage c on a.Position_Id = c.PositionManageId inner join UsersType d on a.UsersType_Id = d.UsersTypeId";
            return MySqlDapper.DapperQuery<UsersInfo>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddUsersInfo(UsersInfo users)
        {
            string sql = "insert into UsersInfo values(null,@UsersName,@UsersSex,@UsersPhone,@DepartMent_Id,@Position_Id,@UsersSchool,@UsersMajor,@UsersAddress,@UsersEducation,@PolitocsStatus,@Nation,@NativePlace,@Marriage,@BirthDate,@UsersEmail,@IdNamber,@StartCompanyDate,@WorkAge,@UsersType_Id,@UsersState,@UsersCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
               @UsersName = users.UsersName,
               @UsersSex = users.UsersSex,
               @UsersPhone = users.UsersPhone,
               @DepartMent_Id = users.DepartMent_Id,
               @Position_Id = users.Position_Id,
               @UsersSchool = users.UsersSchool,
               @UsersMajor = users.UsersMajor,
               @UsersAddress = users.UsersAddress,
               @UsersEducation = users.UsersEducation,
               @PolitocsStatus = users.PolitocsStatus,
               @Nation = users.Nation,
               @NativePlace = users.NativePlace,
               @Marriage = users.Marriage,
               @BirthDate = users.BirthDate,
               @UsersEmail = users.UsersEmail,
               @IdNamber = users.IdNamber,
               @StartCompanyDate = users.StartCompanyDate,
               @WorkAge = users.WorkAge,
                UsersType_Id = users.UsersType_Id,
               @UsersState = users.UsersState,
               @UsersCreateDate = users.UsersCreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UsersInfoId"></param>
        /// <returns></returns>
        public bool DeleteUsersInfo(int UsersInfoId)
        {
            string sql = "DELETE FROM UsersInfo WHERE UsersInfoId IN (@UsersInfoId)";
            return MySqlDapper.DapperExcute(sql, new { @UsersInfoId = UsersInfoId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="UsersInfoId"></param>
        /// <returns></returns>
        public UsersInfo EditUsersInfo(int UsersInfoId)
        {
            string sql = $"select * from UsersInfo where UsersInfoId={UsersInfoId}";
            return MySqlDapper.DapperQuery<UsersInfo>(sql, new { @UsersInfoId = UsersInfoId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool UpdateUsersInfo(UsersInfo users)
        {
            string sql = "UPDATE UsersInfo SET UsersName =@UsersName,UsersSex = @UsersSex,UsersPhone = @UsersPhone,DepartMent_Id = @DepartMent_Id,Position_Id = @Position_Id,UsersSchool = @UsersSchool,UsersMajor = @UsersMajor,UsersAddress = @UsersAddress,UsersEducation = @UsersEducation,PolitocsStatus = @PolitocsStatus,Nation = @Nation,NativePlace = @NativePlace,Marriage = @Marriage,BirthDate = @BirthDate,UsersEmail = @UsersEmail,IdNamber = @IdNamber,StartCompanyDate =@StartCompanyDate,WorkAge = @WorkAge,UsersState = @UsersState, UsersCreateDate = @UsersCreateDate WHERE UsersInfoId = @UsersInfoId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @UsersInfoId=users.UsersInfoId,
                @UsersName = users.UsersName,
                @UsersSex = users.UsersSex,
                @UsersPhone = users.UsersPhone,
                @DepartMent_Id = users.DepartMent_Id,
                @Position_Id = users.Position_Id,
                @UsersSchool = users.UsersSchool,
                @UsersMajor = users.UsersMajor,
                @UsersAddress = users.UsersAddress,
                @UsersEducation = users.UsersEducation,
                @PolitocsStatus = users.PolitocsStatus,
                @Nation = users.Nation,
                @NativePlace = users.NativePlace,
                @Marriage = users.Marriage,
                @BirthDate = users.BirthDate,
                @UsersEmail = users.UsersEmail,
                @IdNamber = users.IdNamber,
                @StartCompanyDate = users.StartCompanyDate,
                @WorkAge = users.WorkAge,
                @UsersState = users.UsersState,
                @UsersCreateDate = users.UsersCreateDate
            });
        }









    }
}
