using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Set;

namespace TMS.IRepository
{
    public interface IPositionManageRepository
    {
        /// <summary>
        /// 职位管理显示
        /// </summary>
        /// <returns></returns>
        List<PositionManage> PositionManageShow();

        /// <summary>
        /// 新增职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool AddPositionManage(PositionManage position);


        /// <summary>
        /// 根据Id删除该职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        bool DeletePosition(int PositionManageId);


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        PositionManage EditPositionManage(int PositionManageId);


        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool UpdatePosition(PositionManage position);

    }
}
