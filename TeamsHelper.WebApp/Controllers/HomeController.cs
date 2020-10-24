using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class HomeController : Controller
    {
        public IUserProvider UserProvider;

        public HomeController(IUserProvider userProvider)
        {
            UserProvider = userProvider;
        }

        [Authorize]
        public async Task<IActionResult> AuthorizedHome()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            if (user.GoogleAuthorization == null || user.MicrosoftAuthorization == null)
            {
                return RedirectToAction("Setup", "Setup");
            }
            
            return View(new ViewModel {User = user});
        }

        [AllowAnonymous]
        public IActionResult Home()
        {
            return View("NotLogged");
        }
    }
}