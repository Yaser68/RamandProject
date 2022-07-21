using Dapper;
using Ramand.Data.Abstractions;
using System.Data;

namespace Ramand.Data;


/// <summary>
/// Implementation class for Repository pattern of user
/// </summary>

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

    public  async Task<bool> GetByAsync(string userName, string password)
    {
        using var connection = _dapperConnection.GetSqlConnection();

        var query = "SP_User_Login";
        return await connection.ExecuteScalarAsync<bool>(query, new { UserName = userName, Password = password }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsAsync(string userName)
    {
        using var connection = _dapperConnection.GetSqlConnection();
       
            var query = "SP_User_Exist ";
            return await connection.ExecuteScalarAsync<bool>(query, new { UserName = userName },
                                                       commandType: CommandType.StoredProcedure);

         
        
       

       
    }
}
