using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;
using LogisticsManagementSystem_IDAL;
using LogisticsManagementSystem_MODEL;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LogisticsManagementSystem_Common;

namespace LogisticsManagementSystem_DAL
{
    public class User : IUser
    {
        public UserModel UserLogin(string name,string password="")
        {
            using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            {
                UserModel user = Dbconnection.Query<UserModel>("SELECT UserName,UserId,UserAge FROM Users WHERE  UserName=@name AND UserPassWord=@password;",new { @name=name,@password=password}).FirstOrDefault();
                return user;
            }
        }

        public UserModel UserLogin(int UserId)
        {
            using (IDbConnection Dbconnection = new MySqlConnection(Connection.conntction))
            {
                UserModel user = Dbconnection.Query<UserModel>($"SELECT * FROM Users WHERE UserId={UserId}").FirstOrDefault();
                return user;
            }
        }
    }
}
