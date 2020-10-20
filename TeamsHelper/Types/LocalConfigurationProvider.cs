using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamsHelper
{
    public class LocalConfigurationProvider : ILocalConfigurationProvider
    {
        public LocalConfiguration Provide()
        {
            const string filename = "local_configuration.json";

            return JsonConvert.DeserializeObject<LocalConfiguration>(File.ReadAllText(filename));
        }
    }
}