using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetuserByIdAsync(string id);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task CreateUserAsync(ApplicationUser user, string password, string role);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<string> GetUserRoleAsync(ApplicationUser user);
    }
}