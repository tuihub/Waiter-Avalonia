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
        public static async Task UpdateLoginState(ApplicationDbContext dbContext, string? accessToken = null, string? refreshToken = null)
        {
            var user = dbContext.Users.First();
            if (accessToken == null || refreshToken == null)
            {
                GlobalContext.UserConfig.IsLoggedIn = false;
                GlobalContext.UserConfig.AccessToken = string.Empty;
                GlobalContext.UserConfig.RefreshToken = string.Empty;
                user.AccessToken = string.Empty;
                user.RefreshToken = string.Empty;
            }
            else
            {
                GlobalContext.UserConfig.IsLoggedIn = true;
                GlobalContext.UserConfig.AccessToken = accessToken;
                GlobalContext.UserConfig.RefreshToken = refreshToken;
                user.AccessToken = accessToken;
                user.RefreshToken = refreshToken;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
