using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface ITokenIdentityGenerator
    {
        Task<Identity> GenerateAsync(OAuthConfiguration authConfiguration, string content);
    }
}