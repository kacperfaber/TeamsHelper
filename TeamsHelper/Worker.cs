using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TeamsHelper
{
    public class Worker : BackgroundService
    {
        public ILocalConfigurationProvider ConfigurationProvider;
        public IMicrosoftTokenRefresher MicrosoftTokenRefresher;
        public IGoogleTokenRefresher GoogleTokenRefresher;
        public TeamsHelper Helper;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                LocalConfiguration localConfig = ConfigurationProvider.Provide();
                string microsoftToken = await MicrosoftTokenRefresher.RefreshAsync(localConfig.MicrosoftRefreshToken, localConfig.MicrosoftClient);
                string googleToken = await GoogleTokenRefresher.RefreshAsync(localConfig.GoogleRefreshToken, localConfig.GoogleClient);

                await Helper.DoSomething(microsoftToken, googleToken);
            }
        }
    }
}