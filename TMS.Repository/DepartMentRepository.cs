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
    public class DepartMentRepository: IDepartMentRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<DepartMent> DepartMentShow()
        {
            string sql = $"select * from DepartMent";
            return MySqlDapper.DapperQuery<DepartMent>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool AddDepartMent(DepartMent depart)
        {
            string sql = "insert into DepartMent values(null,@DepartMentName,@DepartMentCreateDate,@DepartMentParentId)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @DepartMentName = depart.DepartMentName,
                @DepartMentCreateDate = depart.DepartMentCreateDate,
                @DepartMentParentId = depart.DepartMentParentId
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        public bool DeleteDepartMent(int DepartMentId)
        {
            string sql = "DELETE FROM DepartMent WHERE DepartMentId IN (@DepartMentId)";
            return MySqlDapper.DapperExcute(sql, new { @DepartMentId = DepartMentId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        public DepartMent EditDepartMent(int DepartMentId)
        {
            string sql = $"select * from DepartMent where DepartMentId={DepartMentId}";
            return MySqlDapper.DapperQuery<DepartMent>(sql, new { @DepartMentId =DepartMentId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateDepartMent(DepartMent depart)
        {
            string sql = "UPDATE DepartMent SET DepartMentName =@DepartMentName,DepartMentCreateDate =@DepartMentCreateDate,DepartMentParentId = @DepartMentParentId WHERE DepartMentId=@DepartMentId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @DepartMentId = depart.DepartMentId,
                @DepartMentName = depart.DepartMentName,
                @DepartMentCreateDate = depart.DepartMentCreateDate,
                @DepartMentParentId = depart.DepartMentParentId
            });
        }
    }
}
