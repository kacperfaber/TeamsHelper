using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.TeamsApi
{
    public class HttpClient : IHttpClient
    {
        readonly System.Net.Http.HttpClient _http = new System.Net.Http.HttpClient();
        
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _http.SendAsync(request);
        }
    }
}