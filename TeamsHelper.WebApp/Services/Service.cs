﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class Service : BackgroundService
    {
        public TeamsHelper TeamsHelper;
        public IUsersProvider UsersProvider;
        public ITokenRefresher TokenRefresher;
        public IOAuthConfigurationProvider OAuthConfigurationProvider;
        public IConfiguration Configuration;

        public Service(IServiceScopeFactory scopeFactory)
        {
            Factory = scopeFactory.CreateScope();

            TeamsHelper = Factory.ServiceProvider.GetService<TeamsHelper>();
            UsersProvider = Factory.ServiceProvider.GetService<IUsersProvider>();
            TokenRefresher = Factory.ServiceProvider.GetService<ITokenRefresher>();
            OAuthConfigurationProvider = Factory.ServiceProvider.GetService<IOAuthConfigurationProvider>();
            Configuration = Factory.ServiceProvider.GetService<IConfiguration>();
        }

        public IServiceScope Factory { get; set; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                List<User> users = await UsersProvider.ProvideAsync();
                
                OAuthConfiguration googleConfiguration = OAuthConfigurationProvider.Provide(Configuration, "Google");
                OAuthConfiguration microsoftConfiguration = OAuthConfigurationProvider.Provide(Configuration, "Microsoft");
                
                foreach (User user in users)
                {
                    Token googleToken = await TokenRefresher.RefreshAsync(user.GoogleAuthorization, googleConfiguration);
                    Token microsoftToken = await TokenRefresher.RefreshAsync(user.MicrosoftAuthorization, microsoftConfiguration);

                    Raport raport = await TeamsHelper.DoSomething(microsoftToken.AccessToken, googleToken.AccessToken);
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}