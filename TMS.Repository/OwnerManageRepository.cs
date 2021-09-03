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
    public class OwnerManageRepository: IOwnerManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OwnerManage> OwnerManageShow()
        {
            string sql = $"select * from OwnerManage";
            return MySqlDapper.DapperQuery<OwnerManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool AddOwnerManage(OwnerManage owner)
        {
            string sql = "insert into OwnerManage values(null,@OwnerName,@OwnerPhone,@OwnerCompanyName,@OwnerAddress,@CarCardDate,@CarCardPicture,@OwnerRemark,@CreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OwnerName = owner.OwnerName,
                @OwnerPhone = owner.OwnerPhone,
                @OwnerCompanyName = owner.OwnerCompanyName,
                @OwnerAddress = owner.OwnerAddress,
                @CarCardDate = owner.CarCardDate,
                @CarCardPicture = owner.CarCardPicture,
                @OwnerRemark = owner.OwnerRemark,
                @CreateDate = owner.CreateDate
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OwnerManageId"></param>
        /// <returns></returns>
        public bool DeleteOwnerManage(int OwnerManageId)
        {
            string sql = "DELETE FROM OwnerManage WHERE OwnerManageId IN (@OwnerManageId)";
            return MySqlDapper.DapperExcute(sql, new { @OwnerManageId = OwnerManageId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="OwnerManageId"></param>
        /// <returns></returns>
        public OwnerManage EditOwnerManage(int OwnerManageId)
        {
            string sql = $"select * from OwnerManage where OwnerManageId={OwnerManageId}";
            return MySqlDapper.DapperQuery<OwnerManage>(sql, new { @OwnerManageId = OwnerManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool UpdateOwnerManage(OwnerManage owner)
        {
            string sql = "UPDATE OwnerManage SET OwnerName = @OwnerName,OwnerPhone =@OwnerPhone,OwnerCompanyName = @OwnerCompanyName,OwnerAddress = @OwnerAddress,CarCardDate = @CarCardDate,CarCardPicture = @CarCardPicture,OwnerRemark =@OwnerRemark, CreateDate =@CreateDate WHERE OwnerManageId=@OwnerManageId";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OwnerManageId = owner.OwnerManageId,
                @OwnerName = owner.OwnerName,
                @OwnerPhone = owner.OwnerPhone,
                @OwnerCompanyName = owner.OwnerCompanyName,
                @OwnerAddress = owner.OwnerAddress,
                @CarCardDate = owner.CarCardDate,
                @CarCardPicture = owner.CarCardPicture,
                @OwnerRemark = owner.OwnerRemark,
                @CreateDate = owner.CreateDate
            });
        }

    }
}
