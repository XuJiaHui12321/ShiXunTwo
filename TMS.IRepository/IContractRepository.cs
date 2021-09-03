using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.IRepository
{
    public interface IContractRepository
    {
        List<Contract> ContractShow();
        bool AddContract(Contract contract);
        bool DeleteContract(int ContractId);
        Contract EditContract(int ContractId);
        bool UpdateContract(Contract contract);
    }
}
