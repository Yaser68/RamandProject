using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Ramand.Data;

/// <summary>
/// 
/// </summary>
public sealed class DapperConnection
{
    private readonly IOptions<DapperConnectionOptions> _options;

    public DapperConnection(IOptions<DapperConnectionOptions> options)
    {
        _options = options;
    }

    /// <summary>
    /// Creates an instance of SqlConnection. Disposal of the object must be done by the caller.
    /// </summary>
    /// <returns></returns>
    public SqlConnection GetSqlConnection()
    {
        return new SqlConnection(_options.Value.ConnectionString);
    }
}


public sealed class DapperConnectionOptions
{
    public string ConnectionString = default!;
}