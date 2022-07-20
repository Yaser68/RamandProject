using Dapper;
using Microsoft.Extensions.Configuration;
using RamandProject.Common;
using RamandProject.Model;
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
                var query = @"select [UserName],[Id] from [User]";
                var result = await connection.QueryAsync<User>(query);
                return result.ToList();
            }
        }
    }
}
