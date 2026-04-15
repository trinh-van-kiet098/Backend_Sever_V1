using Backend_Game._Module.Match_Map_1.Core;
using Microsoft.AspNetCore.SignalR;
using Backend_Game._Module.Match_Map_1.Core.Entities;
using Backend_Game._Module.TradeModule.Core.Port;
namespace Backend_Game.Shared.Infrastructure.GameHub
{
    public class GameHub : Hub
    {
        private readonly IGameService _gameService;
        private readonly ITradeService _tradeService;
        public GameHub(IGameService gameService, ITradeService tradeService)
        {
            _gameService = gameService;
            _tradeService = tradeService;

        }
        public void SendPosition(string matchId, int x, int y, int z)
        {
            string playerId = Context.ConnectionId;
            _gameService.MovePlayer(matchId, playerId, x, y, z);
        }
        public async Task JoinMatch(string matchId, Guid idPlayer)
        {
            string playerId = idPlayer.ToString();
            await Groups.AddToGroupAsync(playerId, matchId);
            _gameService.AddPlayer(matchId, playerId);
            await Clients.Group(matchId).SendAsync("PlayerJoined", playerId);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string playerId = Context.ConnectionId;
            _gameService.RemovePlayer(playerId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task RequestTrade(string targetPlayerId)
        {
            string playerId = Context.ConnectionId;
            
            await Clients.Client(targetPlayerId).SendAsync("RequestTrade", playerId);
        }
    }
}