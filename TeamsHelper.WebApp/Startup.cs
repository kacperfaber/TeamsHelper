using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TeamsHelper.CalendarApi;
using TeamsHelper.Database;
using TeamsHelper.TeamsApi;
using GetCalendarsRequestGenerator = TeamsHelper.TeamsApi.GetCalendarsRequestGenerator;
using GetCalendarsUrlGenerator = TeamsHelper.TeamsApi.GetCalendarsUrlGenerator;
using IGetCalendarsRequestGenerator = TeamsHelper.TeamsApi.IGetCalendarsRequestGenerator;
using IGetCalendarsUrlGenerator = TeamsHelper.TeamsApi.IGetCalendarsUrlGenerator;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TeamsHelper.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();


            services.AddSingleton<IConfiguration>(x => Configuration);
            
            RegisterServices(services);
            
            services.AddHostedService<Service>();
            
            services.AddMvc(x => x.EnableEndpointRouting = false).AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            });

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("SecretKeys")).SetApplicationName("TeamsHelper");

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.RequireAuthenticatedSignIn = false;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Login/Login");
                    options.LogoutPath = new PathString("/Login/Logout");
                });

            services.AddAuthorization();
            services.AddDbContext<HelperContext>(b => b.UseSqlite("Data Source=.db;", s => s.MigrationsAssembly("TeamsHelper.WebApp")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(new CookiePolicyOptions {MinimumSameSitePolicy = SameSiteMode.Lax});

            app.UseMvc(x => x.MapRoute("default", "{controller}/{action}"));
        }

        void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<GoogleApi>();
            services.AddScoped<ICreateCalendarRequestGenerator, CreateCalendarRequestGenerator>();
            services.AddScoped<ICreateCalendarUrlGenerator, CreateCalendarUrlGenerator>();
            services.AddScoped<CalendarApi.IGetCalendarsRequestGenerator, CalendarApi.GetCalendarsRequestGenerator>();
            services.AddScoped<CalendarApi.IGetCalendarRequestGenerator, CalendarApi.GetCalendarRequestGenerator>();
            services.AddScoped<CalendarApi.IGetCalendarUrlGenerator, CalendarApi.GetCalendarUrlGenerator>();
            services.AddScoped<IInsertEventRequestGenerator, InsertEventRequestGenerator>();
            services.AddScoped<IInsertEventUrlGenerator, InsertEventUrlGenerator>();
            services.AddScoped<IJsonSerializer, CalendarApi.JsonSerializer>();
            services.AddScoped<CalendarApi.IGetCalendarsUrlGenerator, CalendarApi.GetCalendarsUrlGenerator>();
            services.AddScoped<IDeleteEventRequestGenerator, DeleteEventRequestGenerator>();
            services.AddScoped<IDeleteEventUrlGenerator, DeleteEventUrlGenerator>();
            services.AddScoped<IListEventsRequestGenerator, ListEventsRequestGenerator>();
            services.AddScoped<IListEventsUrlGenerator, ListEventsUrlGenerator>();
            services.AddScoped<IUpdateEventRequestGenerator, UpdateEventRequestGenerator>();
            services.AddScoped<IUpdateEventUrlGenerator, UpdateEventUrlGenerator>();
            
            services.AddScoped<IHelperResultGenerator, HelperResultGenerator>();
            services.AddScoped<IEventGenerator, EventGenerator>();
            services.AddScoped<ISynchronizationGenerator, SynchronizationGenerator>();
            services.AddScoped<ISynchronizationEventsGenerator, SynchronizationEventsGenerator>();
            services.AddScoped<ISynchronizationEventGenerator, SynchronizationEventGenerator>();

            services.AddScoped<ISummaryGenerator, SummaryGenerator>();
            services.AddScoped<ICancelledAnnotateGenerator, CancelledAnnotateGenerator>();
            services.AddScoped<IDateTimeConverter, DateTimeConverter>();
            services.AddScoped<ICancelledEventsDescriptionGenerator, CancelledEventsDescriptionGenerator>();
            services.AddScoped<IIsNightChecker, IsNightChecker>();
            services.AddScoped<ISleepTimeProvider, SleepTimeProvider>();
            services.AddScoped<IServiceConfigurationProvider, ServiceConfigurationProvider>();
            services.AddScoped<IUpdateCanceledEventPayloadGenerator, UpdateCanceledEventPayloadGenerator>();
            services.AddScoped<IGoogleEventRemindersGenerator, GoogleEventRemindersGenerator>();
            services.AddScoped<ICancelledEventsUpdater, CancelledEventsUpdater>();
            services.AddScoped<IGoogleConfigurationProvider, GoogleConfigurationProvider>();
            services.AddScoped<ITokenValidationGenerator, TokenValidationGenerator>();
            services.AddScoped<ITokenIdentityGenerator, TokenIdentityGenerator>();
            services.AddScoped<IIdentityRequestGenerator, IdentityRequestGenerator>();
            services.AddScoped<IIdentityRequestMethodProvider, IdentityRequestMethodProvider>();
            services.AddScoped<IAccessTokenValidator, AccessTokenValidator>();
            services.AddScoped<ITeamsEventIsCanceledChecker, TeamsEventIsCanceledChecker>();
            services.AddScoped<ITeamsEventIsActiveValidator, TeamsEventIsActiveValidator>();
            services.AddScoped<IInsertEventPayloadGenerator, InsertEventPayloadGenerator>();
            services.AddScoped<IGoogleEventCorrector, GoogleEventCorrector>();
            services.AddScoped<IUpdateEventPayloadGenerator, UpdateEventPayloadGenerator>();
            services.AddScoped<IGoogleEventsProvider, GoogleEventsProvider>();
            services.AddScoped<IGoogleCalendarCleaner, GoogleCalendarCleaner>();
            services.AddScoped<IGoogleEventPropertiesGenerator, GoogleEventPropertiesGenerator>();
            services.AddScoped<ITeamsEventFinder, TeamsEventFinder>();
            services.AddScoped<IGoogleEventFinder, GoogleEventFinder>();
            services.AddScoped<IGoogleEventHasExtendedPropertiesChecker, GoogleEventHasExtendedPropertiesChecker>();
            services.AddScoped<ITokenValidator, TokenValidator>();
            services.AddScoped<IAuthorizationValidator, AuthorizationValidator>();
            services.AddScoped<IGetCalendarRequestGenerator, GetCalendarRequestGenerator>();
            services.AddScoped<IGetCalendarUrlGenerator, GetCalendarUrlGenerator>();
            services.AddScoped<IAuthenticationPropertiesGenerator, AuthenticationPropertiesGenerator>();
            services.AddScoped<IAuthorizationGenerator, AuthorizationGenerator>();
            services.AddScoped<IClaimsIdentityGenerator, ClaimsIdentityGenerator>();
            services.AddScoped<IDisplayNameIsNotTakenValidator, DisplayNameIsNotTakenValidator>();
            services.AddScoped<IEmailIsNotTakenValidator, EmailIsNotTakenValidator>();
            services.AddScoped<IFormUrlGenerator, FormUrlGenerator>();
            services.AddScoped<IGoogleEventEndGenerator, GoogleEventEndGenerator>();
            services.AddScoped<IGoogleEventStartGenerator, GoogleEventStartGenerator>();
            services.AddScoped<IGoogleEventGenerator, GoogleEventGenerator>();
            services.AddScoped<IGoogleEventsGenerator, GoogleEventsGenerator>();
            services.AddScoped<IGoogleEventSummaryGenerator, GoogleEventSummaryGenerator>();
            services.AddScoped<IGoogleRedirectUrlGenerator, GoogleRedirectUrlGenerator>();
            services.AddScoped<IGoogleTimeGenerator, GoogleTimeGenerator>();
            services.AddScoped<IJsonDeserializer, JsonDeserializer>();
            services.AddScoped<IMicrosoftRedirectUrlGenerator, MicrosoftRedirectUrlGenerator>();
            services.AddScoped<IOAuthConfigurationProvider, OAuthConfigurationProvider>();
            services.AddScoped<IOAuthConfigurationSectionNameGenerator, OAuthConfigurationSectionNameGenerator>();
            services.AddScoped<IPrimaryCalendarProvider, PrimaryCalendarProvider>();
            services.AddScoped<ITeamsCalendarProvider, TeamsCalendarProvider>();
            services.AddScoped<ITeamsCalendarValidator, TeamsCalendarValidator>();
            services.AddScoped<TeamsHelper>();
            services.AddScoped<ITokenContentGenerator, TokenContentGenerator>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<ITokenRefresher, TokenRefresher>();
            services.AddScoped<IEventsDatesGenerator, EventsDatesGenerator>();
            services.AddScoped<IUserGenerator, UserGenerator>();
            services.AddScoped<IUserPasswordValidator, UserPasswordValidator>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUsersProvider, UsersProvider>();
            services.AddScoped<IUserStore, UserStore>();
            services.AddScoped<IGoogleEventValidator, GoogleEventValidator>();
            services.AddScoped<IUserDeletor, UserDeletor>();
            services.AddScoped<WebApp.IHttpClient, WebApp.HttpClient>();

            services.AddScoped<TeamsApi.TeamsApi>();
            services.AddScoped<TeamsApi.IHttpClient, TeamsApi.HttpClient>();
            services.AddScoped<IGetEventsUrlGenerator, GetEventsUrlGenerator>();
            services.AddScoped<IGetEventsRequestGenerator, GetEventsRequestGenerator>();
            services.AddScoped<TeamsApi.IGetCalendarsUrlGenerator, TeamsApi.GetCalendarsUrlGenerator>();
            services.AddScoped<TeamsApi.IGetCalendarsRequestGenerator, TeamsApi.GetCalendarsRequestGenerator>();
        }
    }
}