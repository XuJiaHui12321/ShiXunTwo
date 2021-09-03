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
    public class ContractRepository: IContractRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Contract> ContractShow()
        {
            string sql = $"select * from Contract";
            return MySqlDapper.DapperQuery<Contract>(sql, "");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public bool AddContract(Contract contract)
        {
            string sql = "insert into Contract values(null,ContractBh = @ContractBh,ContractTitle = @ContractTitle,ContractCompany = @ContractCompany,ContractType = @ContractType ,ContractName = @ContractName,ContractDate = @ContractDate ,Principal = @Principal,ContractPrice = @ContractPrice ,ContractRemark = @ContractRemark ,ContractChange = @ContractChange ,ContractText = @ContractText,CreateDate = @CreateDate,ContractState = @ContractState,Approver = @Approver,ApproveRemark = @ApproveRemark)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ContractBh = contract.ContractBh,
                @ContractTitle = contract.ContractTitle,
                @ContractCompany = contract.ContractCompany,
                @ContractType = contract.ContractType,
                @ContractName = contract.ContractName,
                @ContractDate = contract.ContractDate,
                @Principal = contract.Principal,
                @ContractPrice = contract.ContractPrice,
                @ContractRemark = contract.ContractRemark,
                @ContractChange = contract.ContractChange,
                @ContractText = contract.ContractText,
                @CreateDate = contract.CreateDate,
                @ContractState = contract.ContractState,
                @Approver = contract.Approver,
                @ApproveRemark = contract.ApproveRemark
            });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ContractId"></param>
        /// <returns></returns>
        public bool DeleteContract(int ContractId)
        {
            string sql = "DELETE FROM Contract WHERE ContractId IN (@ContractId)";
            return MySqlDapper.DapperExcute(sql, new { @ContractId = ContractId });
        }


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ContractId"></param>
        /// <returns></returns>
        public Contract EditContract(int ContractId)
        {
            string sql = $"select * from Contract where ContractId={ContractId}";
            return MySqlDapper.DapperQuery<Contract>(sql, new { @ContractId = ContractId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool UpdateContract(Contract contract)
        {
            string sql = "UPDATE Contract SET ContractBh = @ContractBh,ContractTitle = @ContractTitle,ContractCompany = @ContractCompany,ContractType = @ContractType ,ContractName = @ContractName,ContractDate = @ContractDate ,Principal = @Principal,ContractPrice = @ContractPrice ,ContractRemark = @ContractRemark ,ContractChange = @ContractChange ,ContractText = @ContractText,CreateDate = @CreateDate,ContractState = @ContractState,Approver = @Approver,ApproveRemark = @ApproveRemark  WHERE ContractId  =@ContractId ;";
            return MySqlDapper.DapperExcute(sql, new
            {
                @ContractId  = contract.ContractId ,
                @ContractBh  = contract.ContractBh ,
                @ContractTitle  = contract.ContractTitle ,
                @ContractCompany  = contract.ContractCompany ,
                @ContractType  = contract.ContractType ,
                @ContractName  = contract.ContractName ,
                @ContractDate  = contract.ContractDate ,
                @Principal  = contract.Principal ,
                @ContractPrice  = contract.ContractPrice ,
                @ContractRemark  = contract.ContractRemark ,
                @ContractChange  = contract.ContractChange ,
                @ContractText = contract.ContractText,
                @CreateDate = contract.CreateDate,
                @ContractState  = contract.ContractState ,
                @Approver  = contract.Approver,
                @ApproveRemark = contract.ApproveRemark
            });
        }
        }
}
