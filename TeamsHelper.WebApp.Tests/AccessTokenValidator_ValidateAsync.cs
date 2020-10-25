using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class AccessTokenValidator_ValidateAsync
    {
        readonly Mock<IIdentityRequestGenerator> RequestGenerator;
        readonly Mock<IHttpClient> HttpClient;
        readonly Mock<ITokenValidationGenerator> Generator;

        public AccessTokenValidator_ValidateAsync()
        {
            RequestGenerator = new Mock<IIdentityRequestGenerator>();
            HttpClient = new Mock<IHttpClient>();
            Generator = new Mock<ITokenValidationGenerator>();
        }

        [Fact]
        public void DontThrows()
        {
            RequestGenerator
                .Setup(x => x.Generate(It.IsAny<string>(), It.IsAny<OAuthConfiguration>()))
                .Returns(new HttpRequestMessage());

            HttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage());

            Generator.Setup(x => x.GenerateAsync(It.IsAny<OAuthConfiguration>(), It.IsAny<HttpResponseMessage>()))
                .ReturnsAsync(new TokenValidation());

            AccessTokenValidator validator = new AccessTokenValidator(RequestGenerator.Object, Generator.Object, HttpClient.Object);

            validator.ValidateAsync(new Token(), new OAuthConfiguration());
        }

        [Fact]
        public async Task ReturnsNotNull()
        {
            RequestGenerator
                .Setup(x => x.Generate(It.IsAny<string>(), It.IsAny<OAuthConfiguration>()))
                .Returns(new HttpRequestMessage());

            HttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage());

            Generator.Setup(x => x.GenerateAsync(It.IsAny<OAuthConfiguration>(), It.IsAny<HttpResponseMessage>()))
                .ReturnsAsync(new TokenValidation());

            AccessTokenValidator validator = new AccessTokenValidator(RequestGenerator.Object, Generator.Object, HttpClient.Object);

            TokenValidation validation = await validator.ValidateAsync(new Token(), new OAuthConfiguration());

            Assert.NotNull(validation);
        }

        [Fact]
        public async Task ReturnsExpected()
        {
            TokenValidation validation = new TokenValidation();

            RequestGenerator
                .Setup(x => x.Generate(It.IsAny<string>(), It.IsAny<OAuthConfiguration>()))
                .Returns(new HttpRequestMessage());

            HttpClient.Setup(x => x.SendAsync(It.IsNotNull<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage());

            Generator.Setup(x => x.GenerateAsync(It.IsNotNull<OAuthConfiguration>(), It.IsNotNull<HttpResponseMessage>()))
                .ReturnsAsync(validation);

            AccessTokenValidator validator = new AccessTokenValidator(RequestGenerator.Object, Generator.Object, HttpClient.Object);

            TokenValidation result = await validator.ValidateAsync(new Token(), new OAuthConfiguration());
            
            Assert.Equal(validation, result);
        }
    }
}