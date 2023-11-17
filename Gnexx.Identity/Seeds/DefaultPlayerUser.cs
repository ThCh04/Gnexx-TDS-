using Gnexx.Identity.Entities;
using Gnexx.Services.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Identity.Seeds
{
    public static class DefaultPlayerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultPlayer = new();
            defaultPlayer.UserName = "playerDoe";
            defaultPlayer.FirstName = "John";
            defaultPlayer.LastName = "Doe";
            defaultPlayer.Email = "seed@gnexx.com";
            defaultPlayer.EmailConfirmed = true;

            if(userManager.Users.All(u => u.Id != defaultPlayer.Id))
            {
                if ( await userManager.FindByEmailAsync(defaultPlayer.Email) == null)
                {
                    await userManager.CreateAsync(defaultPlayer, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultPlayer, Roles.Player.ToString());
                }
            }
        }
    }
}
