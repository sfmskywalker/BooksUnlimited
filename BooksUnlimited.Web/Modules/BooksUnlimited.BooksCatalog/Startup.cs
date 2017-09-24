using System;
using System.Fabric;
using BooksUnlimited.Services.BooksCatalog.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using OrchardCore.Modules;

namespace BooksUnlimited.BooksCatalog
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(serviceProvider =>
            {
                var serviceContext = serviceProvider.GetRequiredService<StatelessServiceContext>();
                var applicationName = serviceContext.CodePackageActivationContext.ApplicationName;
                return ServiceProxy.Create<IBooksCatalogService>(new Uri($"{applicationName}/BooksCatalog"));
            });
        }
    }
}
