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
    /// 货主合同管理
    /// </summary>
    public class OwnerContractRepository: IOwnerContractRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OwnerContract> OwnerContractShow()
        {
            string sql = $"select * from OwnerContract";
            return MySqlDapper.DapperQuery<OwnerContract>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool AddOwnerContract(OwnerContract owner)
        {
            string sql = "insert into OwnerContract values(null,@OwnerContractBh,@OwnerContractTitle,@OwnerContractCompany,@OwnerContractName,@CirCuitManage_Id,@TonFare,@IncludeCarTon,@IncludeCarPrice,@Principal,@ContractDate,@OwnerContractPrice,@ContartRemark,@ContartChange,@ContartText,@CreateDate,@OwnerContractState,@Approver,@ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OwnerContractBh = owner.OwnerContractBh,
                @OwnerContractTitle = owner.OwnerContractTitle,
                @OwnerContractCompany = owner.OwnerContractCompany,
                @OwnerContractName = owner.OwnerContractName,
                @CirCuitManage_Id = owner.CirCuitManage_Id,
                @TonFare = owner.TonFare,
                @IncludeCarTon = owner.IncludeCarTon,
                @IncludeCarPrice = owner.IncludeCarPrice,
                @Principal = owner.Principal,
                @ContractDate = owner.ContractDate,
                @OwnerContractPrice = owner.OwnerContractPrice,
                @ContartRemark = owner.ContartRemark,
                @ContartChange = owner.ContartChange,
                @ContartText = owner.ContartText,
                @CreateDate = owner.CreateDate,
                @OwnerContractState = owner.OwnerContractState,
                @Approver = owner.Approver,
                @ApproveRemark = owner.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OwnerContractId"></param>
        /// <returns></returns>
        public bool DeleteOwnerContract(int OwnerContractId)
        {
            string sql = "DELETE FROM OwnerContract WHERE OwnerContractId IN (@OwnerContractId)";
            return MySqlDapper.DapperExcute(sql, new { @OwnerContractId = OwnerContractId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="OwnerContractId"></param>
        /// <returns></returns>
        public OwnerContract EditOwnerContract(int OwnerContractId)
        {
            string sql = $"select * from OwnerContract where OwnerContractId={OwnerContractId}";
            return MySqlDapper.DapperQuery<OwnerContract>(sql, new { @OwnerContractId = OwnerContractId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UpdateOwnerContract(OwnerContract owner)
        {
            string sql = "UPDATE OwnerContract SET OwnerContractBh = @OwnerContractBh,OwnerContractTitle = @OwnerContractTitle,OwnerContractCompany = @OwnerContractCompany,OwnerContractName = @OwnerContractName,CirCuitManage_Id = @CirCuitManage_Id,TonFare = @TonFare,IncludeCarTon = @IncludeCarTon,IncludeCarPrice = @IncludeCarPrice,Principal = @Principal,ContractDate = @ContractDate,OwnerContractPrice = @OwnerContractPrice,ContartRemark = @ContartRemark,ContartChange = @ContartChange,ContartText = @ContartText,CreateDate = @CreateDate,OwnerContractState = @OwnerContractState,Approver = @Approver,ApproveRemark = @ApproveRemark WHERE OwnerContractId=@OwnerContractId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @OwnerContractId = owner.OwnerContractId,
                @OwnerContractBh = owner.OwnerContractBh,
                @OwnerContractTitle = owner.OwnerContractTitle,
                @OwnerContractCompany = owner.OwnerContractCompany,
                @OwnerContractName = owner.OwnerContractName,
                @CirCuitManage_Id = owner.CirCuitManage_Id,
                @TonFare = owner.TonFare,
                @IncludeCarTon = owner.IncludeCarTon,
                @IncludeCarPrice = owner.IncludeCarPrice,
                @Principal = owner.Principal,
                @ContractDate = owner.ContractDate,
                @OwnerContractPrice = owner.OwnerContractPrice,
                @ContartRemark = owner.ContartRemark,
                @ContartChange = owner.ContartChange,
                @ContartText = owner.ContartText,
                @CreateDate = owner.CreateDate,
                @OwnerContractState = owner.OwnerContractState,
                @Approver = owner.Approver,
                @ApproveRemark = owner.ApproveRemark
            });
        }
    }
}
