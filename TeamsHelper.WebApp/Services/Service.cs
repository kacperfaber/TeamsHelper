using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TeamsHelper.WebApp
{
    public class Service : BackgroundService
    {
        public TeamsHelper TeamsHelper;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Get users.
                // for each
                    // Update tokens.
                    // Invoke TeamsHelper.DoSomething
            }
        }
    }
}