using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventPropertiesGenerator
    {
        Task<GoogleEventProperties> GenerateAsync(Dictionary<string, string> dictionary);
    }
}