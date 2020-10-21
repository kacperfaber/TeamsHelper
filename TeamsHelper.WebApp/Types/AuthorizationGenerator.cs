using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class AuthorizationGenerator : IAuthorizationGenerator
    {
        public Task<Authorization> GenerateAsync(string accessToken, string refreshToken)
        {
            return Task.Run(() => new Authorization
            {
                Id = Guid.NewGuid(),
                AccessToken = accessToken,
                RenewToken = refreshToken,
            });
        }
    }
}