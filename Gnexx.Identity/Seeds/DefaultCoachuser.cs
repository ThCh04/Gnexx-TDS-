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
    public class DefaultCoachuser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultCoach = new();
            defaultCoach.UserName = "CoachDoe";
            defaultCoach.FirstName = "Juana";
            defaultCoach.LastName = "Carbajal";
            defaultCoach.Email = "coach@gnexx.com";
            defaultCoach.EmailConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultCoach.Id))
            {
                if (await userManager.FindByEmailAsync(defaultCoach.Email) == null)
                {
                    await userManager.CreateAsync(defaultCoach, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultCoach, Roles.Coach.ToString());
                    await userManager.AddToRoleAsync(defaultCoach, Roles.Player.ToString());
                }
            }
        }
    }
}
