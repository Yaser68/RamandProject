using Dapper;
using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var connectionString = _configuration.GetConnectionString("RamandDb");

            var query = @"select [UserName] 
                         from [User]";



            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<User>(query);
                return result.ToList();
            }
        }
    }
}
