namespace TeamsHelper.WebApp
{
    public class OAuthConfiguration
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUrl { get; set; }

        public string Scopes { get; set; }

        public string TokenEndpoint { get; set; }
    }
}