using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.Model.Entity.MainTain;

namespace TMS.Repository
{
    /// <summary>
    /// 维修记录
    /// </summary>
    public class MainTainRopository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<ServiceManage> MainTainShow()
        {
            string sql = $"select * from ServiceManage";
            return MySqlDapper.DapperQuery<ServiceManage>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public bool AddServiceManage(ServiceManage service)
        {
            string sql = "insert into ServiceManage values(null,@ServiceManageType,@ServiceTitle,@ServiceType,@ServiceCarCard,@ServicePrice,@ServiceMan,@ServiceDescribe,@ServiceDate,@ServiceRemark,@ServiceCreateTime,@ServiceMileage,@ServiceNum)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ServiceManageType = service.ServiceManageType,
                @ServiceTitle = service.ServiceTitle,
                @ServiceType = service.ServiceType,
                @ServiceCarCard = service.ServiceCarCard,
                @ServicePrice = service.ServicePrice,
                @ServiceMan = service.ServiceMan,
                @ServiceDescribe = service.ServiceDescribe,
                @ServiceDate = service.ServiceDate,
                @ServiceRemark = service.ServiceRemark,
                @ServiceCreateTime = service.ServiceCreateTime,
                @ServiceMileage = service.ServiceMileage,
                @ServiceNum = service.ServiceNum
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public bool DeleteServiceManage(int ServiceId)
        {
            string sql = "DELETE FROM ServiceManage WHERE ServiceId IN (@ServiceId)";
            return MySqlDapper.DapperExcute(sql, new { @ServiceId = ServiceId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="DepartMentId"></param>
        /// <returns></returns>
        public ServiceManage EditServiceManage(int ServiceId)
        {
            string sql = $"select * from ServiceManage where ServiceId={ServiceId}";
            return MySqlDapper.DapperQuery<ServiceManage>(sql, new { @ServiceId = ServiceId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateServiceManage(ServiceManage service)
        {
            string sql = "UPDATE ServiceManage SET ServiceManageType = @ServiceManageType,ServiceTitle = @ServiceTitle,ServiceType = @ServiceType,ServiceCarCard = @ServiceCarCard,ServicePrice = @ServicePrice,ServiceMan = @ServiceMan,ServiceDescribe = @ServiceDescribe,ServiceDate = @ServiceDate,ServiceRemark = @ServiceRemark,ServiceCreateTime = @ServiceCreateTime,ServiceMileage = @ServiceMileage,ServiceNum = @ServiceNum WHERE ServiceId = @ServiceId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ServiceId = service.ServiceId,
                @ServiceManageType = service.ServiceManageType,
                @ServiceTitle = service.ServiceTitle,
                @ServiceType = service.ServiceType,
                @ServiceCarCard = service.ServiceCarCard,
                @ServicePrice = service.ServicePrice,
                @ServiceMan = service.ServiceMan,
                @ServiceDescribe = service.ServiceDescribe,
                @ServiceDate = service.ServiceDate,
                @ServiceRemark = service.ServiceRemark,
                @ServiceCreateTime = service.ServiceCreateTime,
                @ServiceMileage = service.ServiceMileage,
                @ServiceNum = service.ServiceNum
            });
        }
    }
}
