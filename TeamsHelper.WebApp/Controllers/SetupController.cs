using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class SetupController : Controller
    {
        public IUserProvider UserProvider;

        public SetupController(IUserProvider userProvider)
        {
            UserProvider = userProvider;
        }

        public async Task<IActionResult> Setup()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            SetupViewModel viewModel = new SetupViewModel
            {
                User = user,
                GoogleAuthorization = user.GoogleAuthorization,
                MicrosoftAuthorization = user.MicrosoftAuthorization
            };

            return View("Setup", viewModel);
        }
    }
}