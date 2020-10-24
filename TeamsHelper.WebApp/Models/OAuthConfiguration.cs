using System.Net.Http;

namespace TeamsHelper.WebApp
{
    public class OAuthConfiguration
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUrl { get; set; }

        public string Scopes { get; set; }

        public string TokenEndpoint { get; set; }

        public string CodeVerifier { get; set; }

        public string CodeChallenge { get; set; }

        public string CodeChallengeMethod { get; set; }

        public string IdentityUrl { get; set; }

        public string IdentityMethod { get; set; }

        public IdentityModelKeys IdentityModelKeys { get; set; }
    }
}