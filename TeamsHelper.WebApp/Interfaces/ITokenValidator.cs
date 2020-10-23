using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface ITokenValidator
    {
        Task<bool> ValidateAsync(Token token);
    }
}