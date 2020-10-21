using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.Extensions.Configuration;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class OAuthController : Controller
    {
        public IUserProvider UserProvider;
        public IGoogleRedirectUrlGenerator GoogleRedirectUrlGenerator;
        public IMicrosoftRedirectUrlGenerator MicrosoftRedirectUrlGenerator;
        public IConfiguration Configuration;

        public OAuthController(IUserProvider userProvider, IGoogleRedirectUrlGenerator googleRedirectUrlGenerator, IConfiguration configuration)
        {
            UserProvider = userProvider;
            GoogleRedirectUrlGenerator = googleRedirectUrlGenerator;
            Configuration = configuration;
        }

        public async Task<IActionResult> AuthorizeGoogle()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            string clientId = Configuration.GetSection("Authorization:Google:Credentials:ClientId").Get<string>();
            string redirectUrl = Url.ActionLink("CallbackGoogle", "OAuth");
            string scopes = "https://www.googleapis.com/auth/calendar%20https://www.googleapis.com/auth/calendar.readonly%20https://www.googleapis.com/auth/calendar.events";
            string url = await GoogleRedirectUrlGenerator.GenerateAsync(clientId, redirectUrl, scopes, "code");
            
            return RedirectPermanent(url);
        }

        public async Task<IActionResult> AuthorizeMicrosoft()
        {
            string url = await GoogleRedirectUrlGenerator.GenerateAsync();
            return RedirectPermanent(url);
        }

        [HttpGet("signin-google")]
        public IActionResult CallbackGoogle(string code)
        {
            return Content("code is " + code);
        }
    }
}