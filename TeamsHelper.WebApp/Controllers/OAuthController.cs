using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.EntityFrameworkCore;
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
        public ITokenProvider TokenProvider;
        public IAuthorizationGenerator AuthorizationGenerator;
        public HelperContext HelperContext;
        public IAuthorizationValidator AuthorizationValidator;
        public ITokenValidator TokenValidator;

        public OAuthController(IUserProvider userProvider, IGoogleRedirectUrlGenerator googleRedirectUrlGenerator, IConfiguration configuration,
            IOAuthConfigurationProvider configurationProvider, IMicrosoftRedirectUrlGenerator microsoftRedirectUrlGenerator,
            ITokenProvider tokenProvider, IAuthorizationGenerator authorizationGenerator, HelperContext helperContext, IAuthorizationValidator authorizationValidator, ITokenValidator tokenValidator)
        {
            UserProvider = userProvider;
            GoogleRedirectUrlGenerator = googleRedirectUrlGenerator;
            Configuration = configuration;
            ConfigurationProvider = configurationProvider;
            MicrosoftRedirectUrlGenerator = microsoftRedirectUrlGenerator;
            TokenProvider = tokenProvider;
            AuthorizationGenerator = authorizationGenerator;
            HelperContext = helperContext;
            AuthorizationValidator = authorizationValidator;
            TokenValidator = tokenValidator;
        }

        [Authorize]
        public async Task<IActionResult> AuthorizeGoogle()
        {
            OAuthConfiguration authConfiguration = ConfigurationProvider.Provide(Configuration, "Google");

            string url = await GoogleRedirectUrlGenerator.GenerateAsync(authConfiguration, "code");

            return RedirectPermanent(url);
        }

        [Authorize]
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
            User user = await UserProvider.ProvideAsync(HttpContext);
            Token token = await TokenProvider.ProvideAsync(code, configuration);

            if (await TokenValidator.ValidateAsync(token))
            {
                Authorization authorization = await AuthorizationGenerator.GenerateAsync(token.AccessToken, token.RefreshToken, DateTime.Now);

                if (await AuthorizationValidator.ValidateAsync(authorization))
                {
                    user.GoogleAuthorization = authorization;

                    HelperContext.Update(user);
                    await HelperContext.SaveChangesAsync();

                    return RedirectToAction("Home", "Home");
                }

                Response.StatusCode = 404;
                return View("AuthorizationValidationFailed", new AuthorizationValidationFailedViewModel {Authorization = authorization, User = user});
            }

            Response.StatusCode = 404;
            return View("TokenValidationFailed", new TokenValidationFailedViewModel {Token = token, User = user});
        }

        [HttpGet("signin-oidc")]
        public async Task<IActionResult> CallbackMicrosoft(string code)
        {
            OAuthConfiguration configuration = ConfigurationProvider.Provide(Configuration, "Microsoft");
            Token token = await TokenProvider.ProvideAsync(code, configuration);

            User user = await UserProvider.ProvideAsync(HttpContext);
            Authorization authorization = await AuthorizationGenerator.GenerateAsync(token.AccessToken, token.RefreshToken, DateTime.Now);
            user.MicrosoftAuthorization = authorization;

            HelperContext.Users.Update(user);
            await HelperContext.SaveChangesAsync();

            return RedirectToAction("Home", "Home");
        }
    }
}