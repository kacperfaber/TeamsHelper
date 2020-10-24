using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TeamsHelper.WebApp
{
    public interface ITokenValidationGenerator
    {
        Task<TokenValidation> GenerateAsync(OAuthConfiguration authConfiguration, HttpResponseMessage response);
    }
}