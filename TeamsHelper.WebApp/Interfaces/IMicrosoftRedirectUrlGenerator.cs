using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IMicrosoftRedirectUrlGenerator 
    {
        Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType);   
    }
}