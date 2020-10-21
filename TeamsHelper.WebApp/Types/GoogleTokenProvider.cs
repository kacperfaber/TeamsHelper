using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class GoogleTokenProvider : IGoogleTokenProvider
    {
        public IGoogleTokenContentGenerator ContentGenerator;
        public IJsonDeserializer JsonDeserializer;
        
        readonly HttpClient _http = new HttpClient();

        public GoogleTokenProvider(IGoogleTokenContentGenerator contentGenerator, IJsonDeserializer jsonDeserializer)
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

            return JsonDeserializer.Deserialize<Token>(await (await _http.SendAsync(request)).Content.ReadAsStringAsync());
        }
    }
}