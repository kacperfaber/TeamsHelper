using System.Net.Http;
using Moq;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class IdentityRequestGenerator_Generate
    {
        readonly Mock<IIdentityRequestMethodProvider> MethodProvider;

        public IdentityRequestGenerator_Generate()
        {
            MethodProvider = new Mock<IIdentityRequestMethodProvider>();
        }

        [Fact]
        public void DontThrows()
        {
            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = "https://www.url.com"
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(HttpMethod.Post);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            _ = generator.Generate("", configuration);
        }

        [Fact]
        public void ReturnsNotNull()
        {
            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = "https://www.url.com"
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(HttpMethod.Post);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            HttpRequestMessage result = generator.Generate("", configuration);

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsExpectedPostMethod()
        {
            HttpMethod method = HttpMethod.Post;

            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = "https://www.url.com"
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(method);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            HttpRequestMessage res = generator.Generate("", configuration);

            Assert.True(res.Method == method);
        }

        [Fact]
        public void ReturnsExpectedGetMethod()
        {
            HttpMethod method = HttpMethod.Get;

            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = "https://www.url.com"
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(method);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            HttpRequestMessage res = generator.Generate("", configuration);

            Assert.True(res.Method == method);
        }

        [Fact]
        public void ReturnsNotNullRequestUri()
        {
            const string url = "https://www.url.com";

            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = url
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(HttpMethod.Post);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            HttpRequestMessage res = generator.Generate("", configuration);

            Assert.NotNull(res.RequestUri);
        }

        [Fact]
        public void ReturnsExpectedRequestUri()
        {
            const string url = "https://www.url.com";

            OAuthConfiguration configuration = new OAuthConfiguration
            {
                IdentityUrl = url
            };

            MethodProvider.Setup(x => x.Provide(configuration)).Returns(HttpMethod.Post);

            IdentityRequestGenerator generator = new IdentityRequestGenerator(MethodProvider.Object);

            HttpRequestMessage res = generator.Generate("", configuration);

            Assert.Equal(url, res.RequestUri.OriginalString);
        }
    }
}