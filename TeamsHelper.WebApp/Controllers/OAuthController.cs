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
    public class OAuthController : Controller
    {
        public IUserProvider UserProvider;
        public IGoogleRedirectUrlGenerator GoogleRedirectUrlGenerator;
        public IMicrosoftRedirectUrlGenerator MicrosoftRedirectUrlGenerator;
        public IOAuthConfigurationProvider ConfigurationProvider;
        public IConfiguration Configuration;
        public IGoogleTokenProvider GoogleTokenProvider;

        public OAuthController(IUserProvider userProvider, IGoogleRedirectUrlGenerator googleRedirectUrlGenerator, IConfiguration configuration, IOAuthConfigurationProvider configurationProvider, IMicrosoftRedirectUrlGenerator microsoftRedirectUrlGenerator, IGoogleTokenProvider googleTokenProvider)
        {
            UserProvider = userProvider;
            GoogleRedirectUrlGenerator = googleRedirectUrlGenerator;
            Configuration = configuration;
            ConfigurationProvider = configurationProvider;
            MicrosoftRedirectUrlGenerator = microsoftRedirectUrlGenerator;
            GoogleTokenProvider = googleTokenProvider;
        }

        public async Task<IActionResult> AuthorizeGoogle()
        {
            OAuthConfiguration authConfiguration = ConfigurationProvider.Provide(Configuration, "Google");

            string url = await GoogleRedirectUrlGenerator.GenerateAsync(authConfiguration, "code");

            return RedirectPermanent(url);
        }

        public async Task<IActionResult> AuthorizeMicrosoft()
        {
            OAuthConfiguration authConfiguration = ConfigurationProvider.Provide(Configuration, "Microsoft");

            string url = await MicrosoftRedirectUrlGenerator.GenerateAsync(authConfiguration, "code");

            return RedirectPermanent(url);
        }

        [HttpGet("signin-google")]
        public async Task<IActionResult> CallbackGoogle(string code)
        {
            OAuthConfiguration configuration = ConfigurationProvider.Provide(Configuration, "Google");
            Token token = await GoogleTokenProvider.ProvideAsync(code, configuration);
            return Json(token);
        }

        [HttpGet("signin-oidc")]
        public IActionResult CallbackMicrosoft()
        {
            string code = HttpContext.Request.Query["code"];
            return Content("ms: code is " + code);
        }
    }
}