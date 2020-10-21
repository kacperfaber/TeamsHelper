using Microsoft.AspNetCore.Authentication;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IAuthenticationPropertiesGenerator
    {
        AuthenticationProperties Generate(User user);
    }
}