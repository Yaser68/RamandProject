using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Ramand.Data;

/// <summary>
/// Class for dapper connection creation
/// </summary>
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