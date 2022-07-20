using RamandProject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RamandProject.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        bool GetByAsync(string userName,string password);
        Task RegisterAsync(User user);
        
    }
}
