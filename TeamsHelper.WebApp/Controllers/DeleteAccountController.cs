using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class DeleteAccountController : Controller
    {
        public IUserProvider UserProvider;
        public IUserDeletor Deletor;

        public DeleteAccountController(IUserProvider userProvider, IUserDeletor deletor)
        {
            UserProvider = userProvider;
            Deletor = deletor;
        }

        public async Task<IActionResult> Delete()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            return View("Delete", new ViewModel {User = user});
        }

        [HttpPost]
        public async Task<IActionResult> ProceedDelete()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);

            bool res = await Deletor.DeleteAsync(user);

            if (res)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Login");
            }

            return Content("Could not delete, something was bad.");
        }
    }
}