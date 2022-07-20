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
    }
}
