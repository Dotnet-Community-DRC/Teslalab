using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public class IdentityUserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityUserRepository()
        {
        }

        public IdentityUserRepository(UserManager<ApplicationUser> userManager,
                                       RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task CreateUserAsync(ApplicationUser user, string password, string role)
        {
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetuserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<string> GetUserRoleAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }
    }
}