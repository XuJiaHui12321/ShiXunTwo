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
    public class RoleModelRepository: IRoleModeRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<RoleModel> RoleModelShow()
        {
            string sql = $"select * from RoleModel";
            return MySqlDapper.DapperQuery<RoleModel>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddRoleModel(RoleModel role)
        {
            string sql = "insert into RoleModel values(null,@RoleName,@RoleRemark,@RoleStatus,@RoleParentId,@RoleOtherName,@RoleCreatDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @RoleName = role.RoleName,
                @RoleRemark = role.RoleRemark,
                @RoleStatus = role.RoleStatus,
                @RoleParentId = role.RoleParentId,
                @RoleOtherName = role.RoleOtherName,
                @RoleCreatDate = role.RoleCreatDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public bool DeleteRoleModel(int RoleId)
        {
            string sql = "DELETE FROM RoleModel WHERE RoleId IN (@RoleId)";
            return MySqlDapper.DapperExcute(sql, new { @RoleId = RoleId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public RoleModel EditRole(int RoleId)
        {
            string sql = $"select * from RoleModel where RoleId={RoleId}";
            return MySqlDapper.DapperQuery<RoleModel>(sql, new { @RoleId = RoleId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateRole(RoleModel role)
        {
            string sql = "UPDATE RoleModel SET RoleName = @RoleName,RoleRemark = @RoleRemark,RoleStatus = @RoleStatus,RoleParentId = @RoleParentId,RoleOtherName = @RoleOtherName,RoleCreatDate = @RoleCreatDate WHERE RoleId=@RoleId";
            return MySqlDapper.DapperExcute(sql, new
            {
                @RoleId = role.RoleId,
                @RoleName = role.RoleName,
                @RoleRemark = role.RoleRemark,
                @RoleStatus = role.RoleStatus,
                @RoleParentId = role.RoleParentId,
                @RoleOtherName = role.RoleOtherName,
                @RoleCreatDate = role.RoleCreatDate
            });
        }
    }
}
