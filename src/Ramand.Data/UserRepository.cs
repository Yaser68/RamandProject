using Dapper;
using Ramand.Data.Abstractions;
using System.Data;

namespace Ramand.Data;

public class UserRepository : IUserRepository
{
    private readonly DapperConnection _dapperConnection;

    public UserRepository(DapperConnection dapperConnection)
    {
        _dapperConnection = dapperConnection;
    }




    public async Task<List<User>> GetUsersAsync()
    {
        using var connection = _dapperConnection.GetSqlConnection();

        var query = "SP_User_GetUser";
        var result = await connection.QueryAsync<User>(query);
        return result.ToList();
    }

    public async Task RegisterAsync(User user)
    {
        using var connection = _dapperConnection.GetSqlConnection();

        var query = "SP_User_Insert";
        await connection.ExecuteAsync(query,
                                      new { UserName = user.UserName, Password = user.Password },
                                      commandType: CommandType.StoredProcedure);
    }

    public Task<bool> GetByAsync(string userName, string password)
    {
        using var connection = _dapperConnection.GetSqlConnection();

        const string query = "SP_User_Login";
        return connection.ExecuteScalarAsync<bool>(query, new { UserName = userName, Password = password }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsAsync(string userName)
    {
        using var connection = _dapperConnection.GetSqlConnection();
        try
        {
            var query = "SP_User_Exist ";
            var found = await connection.ExecuteScalarAsync<bool>(query, new { UserName = userName },
                                                       commandType: CommandType.StoredProcedure);

            return found;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return  false;
    }
}
