using System;
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
        public IAccessTokenValidator AccessTokenValidator;
        public IIsNightChecker IsNightChecker;
        public ISleepTimeProvider SleepTimeProvider;
        public IServiceConfigurationProvider ServiceConfigurationProvider;

        public ISynchronizationGenerator SynchronizationGenerator;
        public HelperContext Context;

        public Service(IServiceScopeFactory scopeFactory)
        {
            Factory = scopeFactory.CreateScope();

            TeamsHelper = Factory.ServiceProvider.GetService<TeamsHelper>();
            UsersProvider = Factory.ServiceProvider.GetService<IUsersProvider>();
            TokenRefresher = Factory.ServiceProvider.GetService<ITokenRefresher>();
            OAuthConfigurationProvider = Factory.ServiceProvider.GetService<IOAuthConfigurationProvider>();
            Configuration = Factory.ServiceProvider.GetService<IConfiguration>();
            AccessTokenValidator = Factory.ServiceProvider.GetService<IAccessTokenValidator>();
            IsNightChecker = Factory.ServiceProvider.GetService<IIsNightChecker>();
            SleepTimeProvider = Factory.ServiceProvider.GetService<ISleepTimeProvider>();
            ServiceConfigurationProvider = Factory.ServiceProvider.GetService<IServiceConfigurationProvider>();
            Context = Factory.ServiceProvider.GetService<HelperContext>();
            SynchronizationGenerator = Factory.ServiceProvider.GetService<ISynchronizationGenerator>();
        }

        public IServiceScope Factory { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ServiceConfiguration serviceConfiguration = ServiceConfigurationProvider.Provide(Configuration);

                List<User> users = await UsersProvider.ProvideAsync();

                OAuthConfiguration googleConfiguration = OAuthConfigurationProvider.Provide(Configuration, "Google");
                OAuthConfiguration microsoftConfiguration = OAuthConfigurationProvider.Provide(Configuration, "Microsoft");

                foreach (User user in users)
                {
                    Token googleToken = await TokenRefresher.RefreshAsync(user.GoogleAuthorization, googleConfiguration);
                    Token microsoftToken = await TokenRefresher.RefreshAsync(user.MicrosoftAuthorization, microsoftConfiguration);

                    TokenValidation googleValidation = await AccessTokenValidator.ValidateAsync(googleToken, googleConfiguration);
                    TokenValidation microsoftValidation = await AccessTokenValidator.ValidateAsync(microsoftToken, microsoftConfiguration);

                    if (googleValidation.Success && microsoftValidation.Success)
                    {
                        HelperResult result = await TeamsHelper.DoSomething(microsoftToken.AccessToken, googleToken.AccessToken);

                        Synchronization sync = SynchronizationGenerator.Generate(result, user);

                        Context.Add(sync);
                        await Context.SaveChangesAsync(stoppingToken);
                    }
                }

                await Task.Delay(SleepTimeProvider.Provide(DateTime.Now, serviceConfiguration), stoppingToken);
            }
        }
    }
}