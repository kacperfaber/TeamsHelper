using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class ClaimsIdentityGenerator : IClaimsIdentityGenerator
    {
        public ClaimsIdentity Generate(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.DisplayName));

            return claimsIdentity;
        }
    }
}