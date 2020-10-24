using System;
using System.Net.Http;

namespace TeamsHelper.WebApp
{
    public class IdentityRequestGenerator : IIdentityRequestGenerator
    {
        public IIdentityRequestMethodProvider RequestMethodProvider;

        public IdentityRequestGenerator(IIdentityRequestMethodProvider requestMethodProvider)
        {
            RequestMethodProvider = requestMethodProvider;
        }

        public HttpRequestMessage Generate(string accessToken, OAuthConfiguration authConfiguration)
        {
            HttpRequestMessage req = new HttpRequestMessage
            {
                Method = RequestMethodProvider.Provide(authConfiguration),
                RequestUri = new Uri(authConfiguration.IdentityUrl)
            };
            
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}