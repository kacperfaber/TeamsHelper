using System.Security.Claims;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IClaimsIdentityGenerator
    {
        ClaimsIdentity Generate(User user);
    }
}