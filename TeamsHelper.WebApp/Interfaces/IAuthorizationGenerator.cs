using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IAuthorizationGenerator
    {
        Task<Authorization> GenerateAsync(string accessToken, string refreshToken, DateTime generatedAt);
    }
}