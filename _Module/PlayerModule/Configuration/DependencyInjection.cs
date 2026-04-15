using Backend_Game._Module.PlayerModule.Infrastructure.Adapters;
using Backend_Game._Module.PlayerModule.Core.Ports;
namespace Backend_Game._Module.PlayerModule.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPlayerModule(this IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            
            return services;
        }
    }
}