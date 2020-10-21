using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IDisplayNameIsNotTakenValidator
    {
        Task<bool> ValidateAsync(string displayName);
    }
}