using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class LoginController : Controller
    {
        public IClaimsIdentityGenerator ClaimsIdentityGenerator;
        public IAuthenticationPropertiesGenerator AuthenticationPropertiesGenerator;
        public IUserProvider UserProvider;
        public IUserPasswordValidator PasswordValidator;

        public LoginController(IClaimsIdentityGenerator claimsIdentityGenerator, IAuthenticationPropertiesGenerator authenticationPropertiesGenerator, IUserProvider userProvider, IUserPasswordValidator passwordValidator)
        {
            ClaimsIdentityGenerator = claimsIdentityGenerator;
            AuthenticationPropertiesGenerator = authenticationPropertiesGenerator;
            UserProvider = userProvider;
            PasswordValidator = passwordValidator;
        }

        public IActionResult Login()
        {
            return View("Login", new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginViewModel loginViewModel)
        {
            User user = await UserProvider.Provide(loginViewModel.Email);

            if (user != null)
            {
                if (await PasswordValidator.ValidateAsync(user, loginViewModel.Password))
                {
                    ClaimsIdentity claimsIdentity = ClaimsIdentityGenerator.Generate(user);
                    AuthenticationProperties props = AuthenticationPropertiesGenerator.Generate(user);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), props);

                    return Json(user);
                }
            }

            return Content("something wrong.");
        }
    }
}