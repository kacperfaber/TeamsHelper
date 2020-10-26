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
        public IJsonDeserializer JsonDeserializer;
        public IHttpClient Http;
        

        public TokenRefresher(IFormUrlGenerator formUrlGenerator, IJsonDeserializer jsonDeserializer, IHttpClient http)
        {
            FormUrlGenerator = formUrlGenerator;
            JsonDeserializer = jsonDeserializer;
            Http = http;
        }

        public async Task<Token> RefreshAsync(Authorization authorization, OAuthConfiguration configuration)
        {
            FormUrlEncodedContent form = await FormUrlGenerator.GenerateAsync("refresh_token", authorization.RenewToken, "refresh_token", configuration.RedirectUrl,
                configuration.ClientId, configuration.ClientSecret);

            HttpRequestMessage req = new HttpRequestMessage
            {
                Content = form,
                Method = HttpMethod.Post,
                RequestUri = new Uri(configuration.TokenEndpoint)
            };

            HttpResponseMessage response = await Http.SendAsync(req);
            string content = await response.Content.ReadAsStringAsync();

            Token token = JsonDeserializer.Deserialize<Token>(content);
            token.ResponseBody = content;
            token.Code = response.StatusCode;
            token.Request = await form.ReadAsStringAsync();
            
            return token;
        }
    }
}