using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class AuthorizationValidator : IAuthorizationValidator
    {
        public Task<bool> ValidateAsync(Authorization authorization)
        {
            return Task.Run(() =>
                !string.IsNullOrEmpty(authorization.Id) && 
                !string.IsNullOrEmpty(authorization.RenewToken) &&
                !string.IsNullOrEmpty(authorization.AccessToken));
        }
    }
}