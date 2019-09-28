using Blazor.Extensions.Storage;
using Blazor.Client.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            services.AddSingleton<IEventService>(c => new EventsService());
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IApiUsageService, ApiUsageService>();
            services.AddSingleton<ICheckoutService, CheckoutService>();
            services.AddSingleton<ISessionStorageService, SessionStorageService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
