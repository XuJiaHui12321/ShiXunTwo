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
    public class PositionManageRepository: IPositionManageRepository
    {

        /// <summary>
        /// 职位显示
        /// </summary>
        /// <returns></returns>
        public List<PositionManage> PositionManageShow()
        {
            string sql = $"select * from PositionManage";
            return MySqlDapper.DapperQuery<PositionManage>(sql, "");
        }

        /// <summary>
        /// 新增职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool AddPositionManage(PositionManage position)
        {
            string sql = "insert into PositionManage values(null,@PositionName,@PositionParentId,@Alias,@PositionCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PositionName = position.PositionName,
                @PositionParentId = position.PositionParentId,
                @Alias = position.Alias,
                @PositionCreateDate = position.PositionCreateDate
            });
        }


        /// <summary>
        /// 根据职位Id删除职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        public bool DeletePosition(int PositionManageId)
        {
            string sql = "DELETE FROM PositionManage WHERE PositionManageId IN (@PositionManageId)";
            return MySqlDapper.DapperExcute(sql, new { @PositionManageId = PositionManageId });
        }


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        public PositionManage EditPositionManage(int PositionManageId)
        {
            string sql = $"select * from PositionManage where PositionManageId={PositionManageId}";
            return MySqlDapper.DapperQuery<PositionManage>(sql, new { @PositionManageId = PositionManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdatePosition(PositionManage position)
        {
            string sql = "UPDATE PositionManage SET PositionName = @PositionName,PositionParentId = @PositionParentId,Alias = @Alias,PositionCreateDate = @PositionCreateDate WHERE PositionManageId=@PositionManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PositionManageId = position.PositionManageId,
                @PositionName = position.PositionName,
                @PositionParentId = position.PositionParentId,
                @Alias = position.Alias,
                @PositionCreateDate = position.PositionCreateDate
            });
        }



    }
}
