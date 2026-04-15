using Backend_Game.Shared.Infrastructure.GameHub;
using Microsoft.AspNetCore.SignalR;
using Backend_Game._Module.Match_Map_1.Core;
namespace Backend_Game._Module.Match_Map_1.Presenstation
{
    public class GameLoopService : BackgroundService
    {

        private readonly IHubContext<GameHub> _hubContext;
        private readonly IServiceProvider _serviceProvider;

        public GameLoopService( IHubContext<GameHub> hubContext, IServiceProvider serviceProvider)
        {
            _hubContext = hubContext;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var gameService = scope.ServiceProvider.GetRequiredService<IGameService>();
                    var matchIds = gameService.GetAllMatchIds();
                    foreach (var matchId in matchIds)
                    {
                        var playerStates = gameService.GetAllPlayerStates(matchId);
                        if (playerStates.Any())
                        {
                            await _hubContext.Clients.Group(matchId).SendAsync("UpdateGameState", playerStates, cancellationToken: stoppingToken);
                        }
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}