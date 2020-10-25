using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using TeamsHelper.Database;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class ClaimsIdentityGenerator_Generate
    {
        ClaimsIdentity exec(User user)
        {
            ClaimsIdentityGenerator generator = new ClaimsIdentityGenerator();
            return generator.Generate(user);
        }

        [Fact]
        public void DontThrows()
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                DisplayName = "Kacper Faber",
                EmailAddress = "kacperf1234@gmail.com"
            };

            exec(user);
        }

        [Fact]
        public void ReturnsSchemeAsCookieAuthenticationScheme()
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                DisplayName = "Kacper Faber",
                EmailAddress = "kacperf1234@gmail.com"
            };

            ClaimsIdentity result = exec(user);
            Assert.Equal(CookieAuthenticationDefaults.AuthenticationScheme, result.AuthenticationType);
        }

        [Theory]
        [InlineData(ClaimTypes.Email)]
        [InlineData(ClaimTypes.NameIdentifier)]
        [InlineData(ClaimTypes.Name)]
        public void HasClaims(string claimType)
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                DisplayName = "Kacper Faber",
                EmailAddress = "kacperf1234@gmail.com"
            };

            ClaimsIdentity result = exec(user);
            
            Assert.True(result.HasClaim(x => x.Type == claimType));
        }

        [Theory]
        [InlineData(ClaimTypes.Email, "kacperf1234@gmail.com")]
        [InlineData(ClaimTypes.NameIdentifier, "kacperfaber")]
        [InlineData(ClaimTypes.Name, "Kacper Faber")]
        public void HasClaimsWithValues(string claimType, string value)
        {
            User user = new User
            {
                Id = "kacperfaber",
                Password = Guid.NewGuid().ToString(),
                DisplayName = "Kacper Faber",
                EmailAddress = "kacperf1234@gmail.com"
            };

            ClaimsIdentity result = exec(user);
            
            Assert.True(result.HasClaim(claimType, value));
        }
    }
}