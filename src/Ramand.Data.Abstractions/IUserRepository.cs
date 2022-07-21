namespace Ramand.Data.Abstractions;

/// <summary>
/// Repository pattern for usermanagement. CRUD Operations will be abstracted here.
/// </summary>
public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<bool> GetByAsync(string userName, string password);
    Task<bool> ExistsAsync(string userName);
    Task RegisterAsync(User user);

}
