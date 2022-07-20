using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace RamandProject.Common
{
    public class DapperConnection
    {

        private readonly IConfiguration _configuration;

        public DapperConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("RamandDb"));
        }
    }
}
