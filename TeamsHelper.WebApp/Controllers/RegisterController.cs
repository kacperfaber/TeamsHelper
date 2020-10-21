using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        public IEmailIsNotTakenValidator EmailIsNotTakenValidator;
        public IDisplayNameIsNotTakenValidator DisplayNameIsNotTakenValidator;
        public IUserGenerator UserGenerator;
        public IUserStore UserStore;

        public RegisterController(IUserStore userStore, IUserGenerator userGenerator, IDisplayNameIsNotTakenValidator displayNameIsNotTakenValidator, IEmailIsNotTakenValidator emailIsNotTakenValidator)
        {
            UserStore = userStore;
            UserGenerator = userGenerator;
            DisplayNameIsNotTakenValidator = displayNameIsNotTakenValidator;
            EmailIsNotTakenValidator = emailIsNotTakenValidator;
        }

        public IActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                bool emailIsNotTaken = await EmailIsNotTakenValidator.ValidateAsync(registerViewModel.EmailAddress);
                bool displayNameIsNotTaken = await DisplayNameIsNotTakenValidator.ValidateAsync(registerViewModel.DisplayName);

                if (emailIsNotTaken && displayNameIsNotTaken)
                {
                    User user = await UserGenerator.GenerateAsync(registerViewModel);
                    await UserStore.StoreAsync(user);

                    return RedirectToAction("Home", "Home");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Email address or display name is taken.");
                }
            }

            return View("Register", registerViewModel);
        }
    }
}