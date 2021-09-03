using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;

namespace TMS.Repository
{
    public class OutSourceManageRepository: IOutSourceManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OutSourceManage> OutSourceManageShow()
        {
            string sql = $"select * from OutSourceManage";
            return MySqlDapper.DapperQuery<OutSourceManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool AddOutSourceManage(OutSourceManage outSource)
        {
            string sql = "insert into OutSourceManage values(null,OutSourceName = @OutSourceName,OutSourcePhone = @OutSourcePhone,OutSourceEmail = @OutSourceEmail,OutSourceAddress = @OutSourceAddress,FicedTelePhone = @FicedTelePhone,OutSourceRemark = @OutSourceRemark,OutSourceCreateDate = @OutSourceCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OutSourceName = outSource.OutSourceName,
                @OutSourcePhone = outSource.OutSourcePhone,
                @OutSourceEmail = outSource.OutSourceEmail,
                @OutSourceAddress = outSource.OutSourceAddress,
                @FicedTelePhone = outSource.FicedTelePhone,
                @OutSourceRemark = outSource.OutSourceRemark,
                @OutSourceCreateDate = outSource.OutSourceCreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OutSourceManageId"></param>
        /// <returns></returns>
        public bool DeleteOutSourceManage(int OutSourceManageId)
        {
            string sql = "DELETE FROM OutSourceManage WHERE OutSourceManageId IN (@OutSourceManageId)";
            return MySqlDapper.DapperExcute(sql, new { @OutSourceManageId = OutSourceManageId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="OutSourceManageId"></param>
        /// <returns></returns>
        public OutSourceManage EditOutSourceManage(int OutSourceManageId)
        {
            string sql = $"select * from DepartMent where OutSourceManageId={OutSourceManageId}";
            return MySqlDapper.DapperQuery<OutSourceManage>(sql, new { @OutSourceManageId = OutSourceManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateOutSourceManage(OutSourceManage outSource)
        {
            string sql = "UPDATE DepartMent SET DepartMentName =@DepartMentName,DepartMentCreateDate =@DepartMentCreateDate,DepartMentParentId = @DepartMentParentId WHERE OutSourceManageId=@OutSourceManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OutSourceManageId = outSource.OutSourceManageId,
                @OutSourceName = outSource.OutSourceName,
                @OutSourcePhone = outSource.OutSourcePhone,
                @OutSourceEmail = outSource.OutSourceEmail,
                @OutSourceAddress = outSource.OutSourceAddress,
                @FicedTelePhone = outSource.FicedTelePhone,
                @OutSourceRemark = outSource.OutSourceRemark,
                @OutSourceCreateDate = outSource.OutSourceCreateDate
            });
        }
    }
}
