using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.IRepository
{
    public interface IOwnerContractRepository
    {
        List<OwnerContract> OwnerContractShow();
        bool AddOwnerContract(OwnerContract owner);
        bool DeleteOwnerContract(int OwnerContractId);
        OwnerContract EditOwnerContract(int OwnerContractId);
        bool UpdateOwnerContract(OwnerContract owner);
    }
}
