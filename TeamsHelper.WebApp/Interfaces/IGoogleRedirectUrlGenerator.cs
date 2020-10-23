using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IGoogleRedirectUrlGenerator
    {
        Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType);
    }
}