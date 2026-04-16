using Backend_Game._Module.PlayerModule.Infrastructure.Adapters;
using Backend_Game._Module.PlayerModule.Core.Ports;
using Backend_Game._Module.Match_Map_1.Infra;
namespace Backend_Game._Module.PlayerModule.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPlayerModule(this IServiceCollection services)
        {
            // services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerRepository, TestPlayer>();


            return services;
        }
    }
}