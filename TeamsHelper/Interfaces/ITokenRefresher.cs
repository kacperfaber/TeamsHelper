using System.Threading.Tasks;

namespace TeamsHelper
{
    public interface ITokenRefresher
    {
        Task<string> RefreshAsync(string refreshToken, ClientCredentials credentials);
    }
}