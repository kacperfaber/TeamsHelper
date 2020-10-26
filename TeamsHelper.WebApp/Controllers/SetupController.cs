using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class SetupController : Controller
    {
        public IUserProvider UserProvider;
        public IConfiguration Configuration;
        public IOAuthConfigurationProvider AuthConfigurationProvider;
        public ITokenRefresher TokenRefresher;
        public IAccessTokenValidator AccessTokenValidator;

        public SetupController(IUserProvider userProvider, IOAuthConfigurationProvider authConfigurationProvider, IConfiguration configuration, ITokenRefresher tokenRefresher, IAccessTokenValidator accessTokenValidator)
        {
            UserProvider = userProvider;
            AuthConfigurationProvider = authConfigurationProvider;
            Configuration = configuration;
            TokenRefresher = tokenRefresher;
            AccessTokenValidator = accessTokenValidator;
        }

        public async Task<IActionResult> Setup()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            SetupViewModel viewModel = new SetupViewModel
            {
                User = user
            };
            
            if (user.GoogleAuthorization != null)
            {
                OAuthConfiguration googleConfiguration = AuthConfigurationProvider.Provide(Configuration, "Google");
                Token googleToken = await TokenRefresher.RefreshAsync(user.GoogleAuthorization, googleConfiguration);
                viewModel.GoogleValidation = await AccessTokenValidator.ValidateAsync(googleToken, googleConfiguration);
                viewModel.GoogleToken = googleToken;
            }

            if (user.MicrosoftAuthorization != null)
            {
                OAuthConfiguration microsoftConfiguration = AuthConfigurationProvider.Provide(Configuration, "Microsoft");
                Token microsoftToken = await TokenRefresher.RefreshAsync(user.MicrosoftAuthorization, microsoftConfiguration);
                viewModel.MicrosoftValidation = await AccessTokenValidator.ValidateAsync(microsoftToken, microsoftConfiguration);
                viewModel.GoogleToken = microsoftToken;
            }

            return View("Setup", viewModel);
        }
    }
}