using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}