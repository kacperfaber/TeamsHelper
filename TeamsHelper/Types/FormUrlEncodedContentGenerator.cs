using System.Collections.Generic;
using System.Net.Http;

namespace TeamsHelper
{
    public class FormUrlEncodedContentGenerator : IFormUrlEncodedContentGenerator
    {
        public FormUrlEncodedContent Generate(string refreshToken, ClientCredentials credentials)
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", credentials.ClientId),
                new KeyValuePair<string, string>("client_secret", credentials.ClientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            });
        }
    }
}