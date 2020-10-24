using System;
using System.Net.Http;

namespace TeamsHelper.WebApp
{
    public class IdentityRequestMethodProvider : IIdentityRequestMethodProvider
    {
        public HttpMethod Provide(OAuthConfiguration authConfiguration)
        {
            if (string.Equals(authConfiguration.IdentityMethod, "get", StringComparison.InvariantCultureIgnoreCase))
                return HttpMethod.Get;
            if (string.Equals(authConfiguration.IdentityMethod, "post", StringComparison.InvariantCultureIgnoreCase))
                return HttpMethod.Post;
            
            throw new InvalidOperationException(authConfiguration.IdentityMethod + " is not recognized. Possible is 'GET' or 'POST'");
        }
    }
}