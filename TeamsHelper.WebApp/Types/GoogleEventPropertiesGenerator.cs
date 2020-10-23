using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class GoogleEventPropertiesGenerator : IGoogleEventPropertiesGenerator
    {
        public Task<GoogleEventProperties> GenerateAsync(Dictionary<string, string> dictionary)
        {
            return Task.Run(() => new GoogleEventProperties {TeamsId = dictionary["teamsId"]});
        }
    }
}