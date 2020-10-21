using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IEmailIsNotTakenValidator
    {
        Task<bool> ValidateAsync(string emailAddress);
    }
}