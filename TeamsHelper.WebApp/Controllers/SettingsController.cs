using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class SettingsController : Controller
    {
        public IUserProvider UserProvider;

        public SettingsController(IUserProvider userProvider)
        {
            UserProvider = userProvider;
        }

        public async Task<IActionResult> Settings()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);
            return View(new ViewModel {User = user});
        }
    }
}