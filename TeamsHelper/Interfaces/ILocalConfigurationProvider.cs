using System.Threading.Tasks;

namespace TeamsHelper
{
    public interface ILocalConfigurationProvider
    {
        LocalConfiguration Provide();
    }
}