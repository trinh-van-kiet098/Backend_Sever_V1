
using Backend_Game._Module.TradeModule.Core.Port;
using Backend_Game._Module.TradeModule.Core.Services;
using Backend_Game._Module.TradeModule.Infrastructure;

namespace Backend_Game._Module.Match_Map_1.Configurations
{

    public static class Dependency
    {
        public static IServiceCollection AddTradeModule(this IServiceCollection services)
        {
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<INotifycation, Notifycation>();
            return services;
        }
    }
}