using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface ITokenContentGenerator
    {
        Task<FormUrlEncodedContent> GenerateAsync(string code, OAuthConfiguration configuration);
    }
}