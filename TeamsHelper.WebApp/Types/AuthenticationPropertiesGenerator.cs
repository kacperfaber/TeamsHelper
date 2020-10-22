using System;
using Microsoft.AspNetCore.Authentication;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class AuthenticationPropertiesGenerator : IAuthenticationPropertiesGenerator
    {
        public AuthenticationProperties Generate(User user)
        {
            return new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(14)
            };
        }
    }
}