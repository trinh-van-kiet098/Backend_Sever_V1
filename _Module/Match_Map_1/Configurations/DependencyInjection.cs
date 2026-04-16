using Backend_Game._Module.Match_Map_1.Infra;
using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.Match_Map_1.Presenstation;
using Backend_Game._Module.Match_Map_1.Core.Service;
namespace Backend_Game._Module.Match_Map_1.Configurations
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddMatchMap1Module(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryMatch, MemoryMatchRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddSignalR(option=>
            {
                option.EnableDetailedErrors = true;
            });
            services.AddHostedService<GameLoopService>();
            services.AddSingleton<IConnectionManage, ConnectionManage>();
            services.AddScoped<IPlayerState, PlayerService>();
            return services;
        }
    }
}