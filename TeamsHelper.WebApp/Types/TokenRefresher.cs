using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class TokenRefresher : ITokenRefresher
    {
        public IFormUrlGenerator FormUrlGenerator;
        
        readonly HttpClient _http = new HttpClient();

        public TokenRefresher(IFormUrlGenerator formUrlGenerator)
        {
            FormUrlGenerator = formUrlGenerator;
        }

        public async Task<string> RefreshAsync(Authorization authorization, OAuthConfiguration configuration)
        {
            HttpRequestMessage req = new HttpRequestMessage()
            {
                Content = await FormUrlGenerator.GenerateAsync("refresh_token", authorization.RenewToken, "refresh_token", configuration.RedirectUrl,
                    configuration.ClientId, configuration.ClientSecret),
                Method = HttpMethod.Post,
                RequestUri = new Uri(configuration.TokenEndpoint)
            };

            string content = await (await _http.SendAsync(req)).Content.ReadAsStringAsync();
            
            throw new NotImplementedException();
            
            return content;
        }
    }
}