using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class AuthorizationGenerator : IAuthorizationGenerator
    {
        public Task<Authorization> GenerateAsync(string accessToken, string refreshToken, DateTime generatedAt)
        {
            return Task.Run(() => new Authorization
            {
                Id = Guid.NewGuid().ToString(),
                AccessToken = accessToken,
                RenewToken = refreshToken,
                GeneratedAt = generatedAt
            });
        }
    }
}