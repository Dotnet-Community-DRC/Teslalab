using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Server.Models.DataSeeding
{
    public class UsersSeeding
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersSeeding(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if (await _roleManager.FindByNameAsync("Admin") != null)
                return;

            // Create role
            var adminRole = new IdentityRole { Name = "Admin" };
            await _roleManager.CreateAsync(adminRole);

            var userRole = new IdentityRole { Name = "User" };
            await _roleManager.CreateAsync(userRole);

            // Create user
            var admin = new ApplicationUser
            {
                Email = "admin@teslalab.com",
                UserName = "admin@teslalab.com",
                FirstName = "Sudi",
                LastName = "Dav"
            };
            await _userManager.CreateAsync(admin, "Sudi@1992");

            await _userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}