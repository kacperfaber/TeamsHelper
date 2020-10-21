using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IRedirectUrlGenerator
    {
        Task<string> GenerateAsync(string clientId, string redirectUrl, string scopes, string responseType);
    }
}