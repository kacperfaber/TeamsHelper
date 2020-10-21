using Microsoft.AspNetCore.Mvc;

namespace TeamsHelper.WebApp
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View("Login", new LoginViewModel());
        }

        [HttpPost]
        public IActionResult LoginPost(LoginViewModel loginViewModel)
        {
            return Content($"login: {loginViewModel.Email}\npass: {loginViewModel.Password}");
        }
    }
}