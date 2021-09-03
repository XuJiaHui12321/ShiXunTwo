using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.IRepository
{
    public interface IAccountsPayableRepository
    {
        List<AccountsPayable> AccountsPayableShow();
        bool AddAccountsPayable(AccountsPayable exit);
        bool DeleteAccountsPayable(int AccountsPayableId);
        AccountsPayable EditAccountsPayable(int AccountsPayableId);
        bool UpdateAccountsPayable(AccountsPayable exit);
    }
}
