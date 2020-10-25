using System.Threading.Tasks;
using Moq;
using TeamsHelper.Database;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class UserPasswordValidatorTests
    {
        [Fact]
        public async Task DontThrowsExceptions()
        {
            Mock<User> user = new Mock<User>();
            user.SetupGet(x => x.Password).Returns("helloWorld!");

            UserPasswordValidator validator = new UserPasswordValidator();

            bool res = await validator.ValidateAsync(user.Object, "helloWorld!");
        }
    }
}