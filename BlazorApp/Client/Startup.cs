using Blazor.Extensions.Storage;
using Blazor.Client.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            var eventService = new EventsService();
            services.AddSingleton<EventsService>(eventService);
            services.AddSingleton<IEventService, EventsService>();
            services.AddSingleton<CartService>(new CartService(eventService));
            services.AddTransient<ApiUsageService>();


        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
