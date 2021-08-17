using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagementSystem_MODEL;

namespace LogisticsManagementSystem_IDAL
{
    public interface IUser
    {
        UserModel UserLogin(string name,string password);

        UserModel UserLogin(int UserId);
    }
}
