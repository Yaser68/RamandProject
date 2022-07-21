using Dapper;
using Microsoft.Extensions.Configuration;
using RamandProject.Common;
using RamandProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RamandProject.Services
{
    public class UserService : IUserService
    {

        private readonly DapperConnection _dapperConnection;

        public UserService(DapperConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }




        public async Task<List<User>> GetUsersAsync()
        {
           
            using (IDbConnection connection=_dapperConnection.GetSqlConnection())
            {
                var query = "SP_User_GetUser";
                var result = await connection.QueryAsync<User>(query);
                return result.ToList();
            }
        }

        public async Task RegisterAsync(User user)
        {
            using (IDbConnection connection = _dapperConnection.GetSqlConnection())
            {
                var query = "SP_User_Insert";
                await connection.ExecuteAsync(query,
                                              new { UserName=user.UserName, Password=user.Password },
                                              commandType: CommandType.StoredProcedure);

            }
        }

        public bool GetByAsync(string userName,string password)
        {
            using (IDbConnection connection = _dapperConnection.GetSqlConnection())
            {
                var query = "SP_User_Login";
                return  connection.ExecuteScalar<bool>(query, new { UserName = userName, Password = password },
                                                                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool Exist(string userName)
        {
            using (IDbConnection connection = _dapperConnection.GetSqlConnection())
            {
                var query = "SP_User_Exist ";
                return connection.ExecuteScalar<bool>(query, new { UserName = userName },
                                                           commandType: CommandType.StoredProcedure);
            }
        }
    }
}
