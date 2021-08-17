using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LogisticsManagementSystem_Common;
using LogisticsManagementSystem_IDAL;
using LogisticsManagementSystem_MODEL;
using MySql.Data.MySqlClient;

namespace LogisticsManagementSystem_DAL
{
    public class VehicleManagement : IVehicleManagement
    {
        /// <summary>
        /// 添加车辆管理
        /// </summary>
        /// <param name="vehicleManagementModel"></param>
        /// <returns></returns>
        public int AddVehicleManagement(VehicleManagementModel vehicleManagementModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <returns></returns>
        public List<VehicleManagementModel> GetVehicleManagementModels(out int pageCount, out int totalRecordCount, int size,int page,string BrandAndModel="",string LicensePlateNumber="",string Company="",string DriverName="")
        {
            //using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            //{
            //    List<VehicleManagementModel> vehicleManagementModels = Dbconnection.Query<VehicleManagementModel>($"SELECT * FROM VehicleManagement").ToList();
            //    DataSet dataSet = (DataSet)Dbconnection.Query<VehicleManagement>("SELECT * FROM VehicleManagement");
            //    return vehicleManagementModels;
            //}
            if (BrandAndModel==null)
            {
                BrandAndModel = "";
            }
            if (LicensePlateNumber == null)
            {
                LicensePlateNumber = "";
            }
            if (Company == null)
            {
                Company = "";
            }
            if (DriverName == null)
            {
                DriverName = "";
            }
            using (IDbConnection dbConnection = new MySqlConnection(Connection.conntction))
            {
                var parameters = new DynamicParameters();
                //DynamicParameters[] dynamicParameters = new DynamicParameters[] {
                //    new DynamicParameters("size",DbType.Int32,ParameterDirection.Output);
                //};
                var p = new DynamicParameters();
                p.Add("@size", size,dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@page",page, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BrandAndModel", BrandAndModel, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@LicensePlateNumber", LicensePlateNumber, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@Company", Company, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@DriverName", DriverName, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@pageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@totalRecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                List<VehicleManagementModel> list = dbConnection.Query<VehicleManagementModel>("VehicleManagementPaging", p, commandType: CommandType.StoredProcedure).ToList();
                pageCount = p.Get<int>("@pageCount");
                totalRecordCount = p.Get<int>("@totalRecordCount");
                return list;
            }

        }
    }
}
