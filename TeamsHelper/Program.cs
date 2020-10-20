using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spencer.NET;

namespace TeamsHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    LocalConfiguration localConfig = hostContext.Configuration.GetSection("LocalConfiguration").Get<LocalConfiguration>();

                    IContainer c = ContainerFactory.Container();
                    c.ResolveOrAuto<TeamsHelper>();

                    services.AddHostedService<Worker>();
                });
        
    }
}