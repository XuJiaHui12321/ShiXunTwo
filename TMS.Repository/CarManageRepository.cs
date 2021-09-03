using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;


namespace TMS.Repository
{
    public class CarManageRepository:ICarManageRepository
    {
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> CarShow()
        {
            string sql = $"select * from CarManage";
            return MySqlDapper.DapperQuery<CarManage>(sql, "");
        }


        public List<CarManage> CarShowPage()
        {
            using (IDbConnection conn = new MySqlConnection(DbFactory.DbConString))
            {
                string readSp = $"select * from CarManage";
                return conn.Query<CarManage>(readSp, commandType: CommandType.StoredProcedure).ToList();
            }
          
        }


        /// <summary>
        /// 存储过程分页+状态查询
        /// </summary>
        /// <param name="status">状态查询</param>
        /// <param name="pageIndex">当期第几页</param>
        /// <param name="pageSize">每页几条数据</param>
        /// <param name="totalCount">总计数量</param>
        /// <returns></returns>
        public List<CarManage> GeCarManagePage(int pageIndex, int pageSize, out int totalCount)
        {
            DynamicParameters dynamic = new DynamicParameters();//动态参数       
            dynamic.Add("_pageIndex", pageIndex, DbType.Int32);
            dynamic.Add("_pageSize", pageSize, DbType.Int32);
            dynamic.Add("_totalCount", null, DbType.Int32, ParameterDirection.Output);//输出型
            //调用存储过程
            var data = MySqlDapper.DapperQuery<CarManage>("sp_viewpage", dynamic, true).ToList();
            //拿到总计数量
            totalCount = dynamic.Get<int>("_totalCount");
            return data;
        }


        /// <summary>
        /// 新增汽车
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool AddCarManage(CarManage car)
        {
            string sql = "insert into CarManage values(null,@FactoryPlate,@CarPlate,@DriverName,@SubordinateCompany,@Cartype,@CarColor,@BuyDate,@OperationPlate,@InsuranceExpriration,@AnnualInspection,@UpKeepKm,@CarPicture,@UpKeepKmPicture)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @FactoryPlate = car.FactoryPlate,
                @CarPlate = car.CarPlate,
                @DriverName = car.DriverName,
                @SubordinateCompany = car.SubordinateCompany,
                @Cartype = car.Cartype,
                @CarColor = car.CarColor,
                @BuyDate = car.BuyDate,
                @OperationPlate = car.OperationPlate,
                @InsuranceExpriration = car.InsuranceExpriration,
                @AnnualInspection = car.AnnualInspection,
                @UpKeepKm = car.UpKeepKm,
                @CarPicture = car.CarPicture,
                @UpKeepKmPicture = car.UpKeepKmPicture            
            });
        }


        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        public bool DeleteCar(int CarManageId)
        {
            string sql = "DELETE FROM CarManage WHERE CarManageId IN (@CarManageId)";
            return MySqlDapper.DapperExcute(sql, new { @CarManageId = CarManageId });
        }


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        public CarManage EditCarManage(int CarManageId)
        {
            string sql = $"select * from CarManage where CarManageId={CarManageId}";
            return MySqlDapper.DapperQuery<CarManage>(sql, new { @CarManageId = CarManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改该汽车
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdateCar(CarManage car)
        {
            string sql = "UPDATE CarManage SET FactoryPlate = @FactoryPlate,CarPlate = @CarPlate,DriverName = @DriverName,SubordinateCompany =@SubordinateCompany,Cartype = @Cartype,CarColor = @CarColor,BuyDate = @BuyDate,OperationPlate = @OperationPlate,InsuranceExpriration = @InsuranceExpriration,AnnualInspection = @AnnualInspection,UpKeepKm = @UpKeepKm,CarPicture = @CarPicture,UpKeepKmPicture = @UpKeepKmPicture WHERE CarManageId=@CarManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @CarManageId = car.CarManageId,
                @FactoryPlate = car.FactoryPlate,
                @CarPlate = car.CarPlate,
                @DriverName = car.DriverName,
                @SubordinateCompany = car.SubordinateCompany,
                @Cartype = car.Cartype,
                @CarColor = car.CarColor,
                @BuyDate = car.BuyDate,
                @OperationPlate = car.OperationPlate,
                @InsuranceExpriration = car.InsuranceExpriration,
                @AnnualInspection = car.AnnualInspection,
                @UpKeepKm = car.UpKeepKm,
                @CarPicture = car.CarPicture,
                @UpKeepKmPicture = car.UpKeepKmPicture
            });
        }


    }
}
