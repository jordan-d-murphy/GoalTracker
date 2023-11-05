using System.Configuration;
using GoalTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace GoalTracker.Utils;

public static class Utils
{
    public async static Task<bool> CreateUser(string username, string email, string password, string[] roles, UserManager<ApplicationUser> userManager)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email
        };

        var _user = await userManager.FindByEmailAsync(email);

        if (_user == null)
        {
            var createUser = await userManager.CreateAsync(user, password);

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
        return false;
    }
}
