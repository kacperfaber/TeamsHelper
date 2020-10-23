using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class TokenProvider : ITokenProvider
    {
        public ITokenContentGenerator ContentGenerator;
        public IJsonDeserializer JsonDeserializer;
        
        readonly HttpClient _http = new HttpClient();

        public TokenProvider(ITokenContentGenerator contentGenerator, IJsonDeserializer jsonDeserializer)
        {
            ContentGenerator = contentGenerator;
            JsonDeserializer = jsonDeserializer;
        }

        public async Task<Token> ProvideAsync(string code, OAuthConfiguration authConfiguration)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(authConfiguration.TokenEndpoint),
                Content = await ContentGenerator.GenerateAsync(code, authConfiguration),
                Method = HttpMethod.Post
            };

            HttpResponseMessage response = await _http.SendAsync(request);

            return JsonDeserializer.Deserialize<Token>(await response.Content.ReadAsStringAsync());
        }
    }
}