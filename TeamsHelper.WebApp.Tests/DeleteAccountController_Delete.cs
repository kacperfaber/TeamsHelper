using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TeamsHelper.Database;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class DeleteAccountController_Delete
    {
        readonly Mock<IUserProvider> UserProvider;

        public DeleteAccountController_Delete()
        {
            UserProvider = new Mock<IUserProvider>();
        }

        [Fact]
        public void DontThrows()
        {
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(new User());

            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            controller.Delete();
        }

        [Fact]
        public async Task IsViewResult()
        {
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(new User());
            
            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            IActionResult result = await controller.Delete();

            Assert.True(result is ViewResult);
        }

        [Fact]
        public async Task NotNullModel()
        {
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(new User());
            
            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            ViewResult result = (ViewResult) await controller.Delete();
            
            Assert.NotNull(result.Model);
        }

        [Fact]
        public async Task ModelIsViewModel()
        {
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(new User());
            
            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            ViewResult result = (ViewResult) await controller.Delete();
            
            Assert.True(result.Model is ViewModel);
        }

        [Fact]
        public async Task NotNullModelUser()
        {
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(new User());
            
            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            ViewResult result = (ViewResult) await controller.Delete();

            ViewModel model = (ViewModel) result.Model;
            
            Assert.NotNull(model.User);
        }
        
        [Fact]
        public async Task ExpectedModelUser()
        {
            User user = new User();
            
            UserProvider.Setup(x => x.ProvideAsync(It.IsAny<HttpContext>())).ReturnsAsync(user);
            
            DeleteAccountController controller = new DeleteAccountController(UserProvider.Object, null);

            ViewResult result = (ViewResult) await controller.Delete();

            ViewModel model = (ViewModel) result.Model;
            
            Assert.Equal(user, model.User);
        }
    }
}