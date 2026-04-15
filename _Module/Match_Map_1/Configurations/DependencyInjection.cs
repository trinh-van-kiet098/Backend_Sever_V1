using Backend_Game._Module.Match_Map_1.Infra;
using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.Match_Map_1.Presenstation;
namespace Backend_Game._Module.Match_Map_1.Configurations
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddMatchMap1Module(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryMatch, MemoryMatchRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddSignalR();
            services.AddHostedService<GameLoopService>();
            return services;
        }
    }
}