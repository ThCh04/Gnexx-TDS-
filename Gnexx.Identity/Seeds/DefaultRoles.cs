using Gnexx.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Gnexx.Services.Enums;

namespace Gnexx.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Coach.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Player.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        }
    }
}
