using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BaseInfo;

namespace TMS.IRepository
{
    public interface ICarManageRepository
    {
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        List<CarManage> CarShow();

        List<CarManage> GeCarManagePage(int pageIndex, int pageSize, out int totalCount);


        /// <summary>
        /// 新增汽车
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        bool AddCarManage(CarManage car);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        bool DeleteCar(int CarManageId);


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        CarManage EditCarManage(int CarManageId);

        /// <summary>
        /// 修改该汽车
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        bool UpdateCar(CarManage car);

       


    }
}
