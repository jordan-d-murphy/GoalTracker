using System.Configuration;
using GoalTracker.Areas.Identity.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Utils;

public static class Utils
{



    public static async Task SetUpDefaultUser(WebApplicationBuilder builder, UserManager<ApplicationUser> userManager, string userMoniker, string[] roles)
    {
        var user = builder.Configuration.GetSection(userMoniker).Get<TestUser>();


        if (user is null || String.IsNullOrEmpty(user.UserName) || String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password))
        {
            // unable to fetch config 
            throw new ConfigurationErrorsException("Unable to read AppSettings.json");
        }
        else
        {
            var success = await CreateUser(user, roles, userManager);
        }
    }


    public async static Task<bool> CreateUser(TestUser testUser, string[] roles, UserManager<ApplicationUser> userManager)
    {
        if (!String.IsNullOrEmpty(testUser.Email) && !String.IsNullOrEmpty(testUser.UserName) && !String.IsNullOrEmpty(testUser.Password))
        {
            var user = new ApplicationUser
            {
                UserName = testUser.UserName,
                Email = testUser.Email
            };

            var _user = await userManager.FindByEmailAsync(testUser.Email);

            if (_user == null)
            {
                var createUser = await userManager.CreateAsync(user, testUser.Password);

                if (createUser.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var result = await userManager.ConfirmEmailAsync(user, code);

                    if (result.Succeeded)
                    {
                        var roleResult = await userManager.AddToRolesAsync(user, roles);

                        if (roleResult.Succeeded)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }


}
