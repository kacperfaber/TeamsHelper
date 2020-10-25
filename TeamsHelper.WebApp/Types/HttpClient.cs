using System.Net.Http;
using System.Threading.Tasks;
using Client = System.Net.Http.HttpClient;

namespace TeamsHelper.WebApp
{
    public class HttpClient : IHttpClient
    {
        readonly Client _http = new Client();
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _http.SendAsync(request);
        }
    }
}