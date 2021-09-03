using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Contract;

namespace TMS.Repository
{
    /// <summary>
    /// 承运合同管理
    /// </summary>
    public class CarrierContractRepository: ICarrierContractRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<CarrierContract> CarrierContractShow()
        {
            string sql = $"select * from CarrierContract";
            return MySqlDapper.DapperQuery<CarrierContract>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public bool AddCarrierContract(CarrierContract carrier)
        {
            string sql = "insert into CarrierContract values(null,@CarrierContractBh,@CarrierContractTitle,@CarrierContractCompany,@CarrierContractName,@CirCuitManage_Id,@TonFare,@IncludeCarTon,@IncludeCarPrice,@Principal,@ContractDate,@CarrierContractPrice,@CarrierContractRemark,@CarrierContractChange,@CarrierContractText,@CreateDate,@CarrierContractState,@Approver,@ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @CarrierContractBh = carrier.CarrierContractBh,
                @CarrierContractTitle = carrier.CarrierContractTitle,
                @CarrierContractCompany = carrier.CarrierContractCompany,
                @CarrierContractName = carrier.CarrierContractName,
                @CirCuitManage_Id = carrier.CirCuitManage_Id,
                @TonFare = carrier.TonFare,
                @IncludeCarTon = carrier.IncludeCarTon,
                @IncludeCarPrice = carrier.IncludeCarPrice,
                @Principal = carrier.Principal,
                @ContractDate = carrier.ContractDate,
                @CarrierContractPrice = carrier.CarrierContractPrice,
                @CarrierContractRemark = carrier.CarrierContractRemark,
                @CarrierContractChange = carrier.CarrierContractChange,
                @CarrierContractText = carrier.CarrierContractText,
                @CreateDate = carrier.CreateDate,
                @CarrierContractState = carrier.CarrierContractState,
                @Approver = carrier.Approver,
                @ApproveRemark = carrier.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarrierContractId"></param>
        /// <returns></returns>
        public bool DeleteCarrierContract(int CarrierContractId)
        {
            string sql = "DELETE FROM CarrierContract WHERE CarrierContractId IN (@CarrierContractId)";
            return MySqlDapper.DapperExcute(sql, new { @CarrierContractId = CarrierContractId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="CarrierContractId"></param>
        /// <returns></returns>
        public CarrierContract EditCarrierContract(int CarrierContractId)
        {
            string sql = $"select * from CarrierContract where CarrierContractId={CarrierContractId}";
            return MySqlDapper.DapperQuery<CarrierContract>(sql, new { @CarrierContractId = CarrierContractId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public bool UpdateCarrierContract(CarrierContract carrier)
        {
            string sql = "UPDATE CarrierContract SET CarrierContractId=@CarrierContractId,CarrierContractBh = @CarrierContractBh,CarrierContractTitle = @CarrierContractTitle,CarrierContractCompany = @CarrierContractCompany,CarrierContractName = @CarrierContractName,CirCuitManage_Id = @CirCuitManage_Id,TonFare = @TonFare,IncludeCarTon = @IncludeCarTon,IncludeCarPrice = @IncludeCarPrice,Principal = @Principal,ContractDate = @ContractDate,CarrierContractPrice = @CarrierContractPrice,CarrierContractRemark = @CarrierContractRemark,CarrierContractChange = @CarrierContractChange,CarrierContractText = @CarrierContractText,CreateDate = @CreateDate,CarrierContractState = @CarrierContractState,Approver = @Approver,ApproveRemark = @ApproveRemark WHERE CarrierContractId =@CarrierContractId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @CarrierContractId=carrier.CarrierContractId,
                @CarrierContractBh = carrier.CarrierContractBh,
                @CarrierContractTitle = carrier.CarrierContractTitle,
                @CarrierContractCompany = carrier.CarrierContractCompany,
                @CarrierContractName = carrier.CarrierContractName,
                @CirCuitManage_Id = carrier.CirCuitManage_Id,
                @TonFare = carrier.TonFare,
                @IncludeCarTon = carrier.IncludeCarTon,
                @IncludeCarPrice = carrier.IncludeCarPrice,
                @Principal = carrier.Principal,
                @ContractDate = carrier.ContractDate,
                @CarrierContractPrice = carrier.CarrierContractPrice,
                @CarrierContractRemark = carrier.CarrierContractRemark,
                @CarrierContractChange = carrier.CarrierContractChange,
                @CarrierContractText = carrier.CarrierContractText,
                @CreateDate = carrier.CreateDate,
                @CarrierContractState = carrier.CarrierContractState,
                @Approver = carrier.Approver,
                @ApproveRemark = carrier.ApproveRemark
            });
        }
    }
}
