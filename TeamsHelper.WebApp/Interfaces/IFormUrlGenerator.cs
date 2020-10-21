using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IFormUrlGenerator
    {
        Task<FormUrlEncodedContent> GenerateAsync(string accessName, string accessValue, string grantType, string redirectUrl, string clientId,
            string clientSecret);
    }
}