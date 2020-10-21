using Microsoft.AspNetCore.Authentication;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class AuthenticationPropertiesGenerator : IAuthenticationPropertiesGenerator
    {
        public AuthenticationProperties Generate(User user)
        {
            return new AuthenticationProperties();
        }
    }
}