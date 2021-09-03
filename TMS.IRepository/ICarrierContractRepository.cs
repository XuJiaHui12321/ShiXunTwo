using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Contract;

namespace TMS.IRepository
{
    public interface ICarrierContractRepository
    {
        List<CarrierContract> CarrierContractShow();
        bool AddCarrierContract(CarrierContract carrier);
        bool DeleteCarrierContract(int CarrierContractId);
        CarrierContract EditCarrierContract(int CarrierContractId);
        bool UpdateCarrierContract(CarrierContract carrier);
    }
}
