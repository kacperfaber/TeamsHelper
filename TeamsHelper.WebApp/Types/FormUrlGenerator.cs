using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class FormUrlGenerator : IFormUrlGenerator
    {
        public Task<FormUrlEncodedContent> GenerateAsync(string accessName, string accessValue, string grantType, string redirectUrl, string clientId, string clientSecret)
        {
            return Task.Run(() =>
            {
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(accessName, accessValue),
                    new KeyValuePair<string, string>("grant_type", grantType),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("redirect_uri", redirectUrl)
                };

                return new FormUrlEncodedContent(pairs);
            });
        }
    }
}