using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class OAuthController : Controller
    {
        public IUserProvider UserProvider;
        public IGoogleRedirectUrlGenerator GoogleRedirectUrlGenerator;

        public OAuthController(IUserProvider userProvider)
        {
            UserProvider = userProvider;
        }

        public async Task<IActionResult> AuthorizeGoogle()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            return Challenge(new AuthenticationProperties {RedirectUri = "/signin-google"}, GoogleDefaults.AuthenticationScheme);
        }

        public IActionResult AuthorizeMicrosoft()
        {
            throw new NotImplementedException();
        }

        [HttpGet("signin-google")]
        public IActionResult CallbackGoogle(string code)
        {
            return Content("code is " + code);
        }
    }
}