using RamandProject.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RamandProject.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        bool GetByAsync(string userName,string password);
        bool Exist(string userName);
        Task RegisterAsync(User user);
        
    }
}
