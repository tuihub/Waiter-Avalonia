using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.Models.Db;

namespace Waiter.Helpers
{
    public static class GlobalContextStateHelper
    {
        // set token to null to clear login state
        public static async Task UpdateLoginState(GlobalContext context, ApplicationDbContext dbContext, string? accessToken = null, string? refreshToken = null)
        {
            var user = dbContext.Users.First();
            if (accessToken == null || refreshToken == null)
            {
                context.UserConfig.IsLoggedIn = false;
                context.UserConfig.AccessToken = string.Empty;
                context.UserConfig.RefreshToken = string.Empty;
                user.AccessToken = string.Empty;
                user.RefreshToken = string.Empty;
            }
            else
            {
                context.UserConfig.IsLoggedIn = true;
                context.UserConfig.AccessToken = accessToken;
                context.UserConfig.RefreshToken = refreshToken;
                user.AccessToken = accessToken;
                user.RefreshToken = refreshToken;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
