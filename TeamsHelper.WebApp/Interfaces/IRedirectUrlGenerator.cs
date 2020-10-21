using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IRedirectUrlGenerator
    {
        Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType);
    }
}