using Backend_Game._Module.TradeModule.Core.Port;
using Backend_Game._Module.TradeModule.Core.Entities;
using Backend_Game._Module.Match_Map_1.Core;
using Microsoft.AspNetCore.SignalR;
using Backend_Game.Shared.Infrastructure.GameHub;
namespace Backend_Game._Module.TradeModule.Infrastructure
{
    public class Notifycation : INotifycation
    {
        private readonly IConnectionManage _connectionManage;
        private readonly IHubContext<GameHub> _hubContext;
        public Notifycation(IConnectionManage connectionManage, IHubContext<GameHub> gameHub)
        {
            _connectionManage = connectionManage;
            _hubContext = gameHub;
        }
        public async Task NotifycationTrade(string toPlayerId, Trade trade)
        {
            string? connectId = _connectionManage.GetConnectionId(toPlayerId);
            if (connectId != null)
            {
                await _hubContext.Clients.Client(connectId).SendAsync("ReceiveTradeOffer", trade);
            }
        }
        public async Task NotifycationResultTrade(string playerId, string result)
        {
            string ?connectId= _connectionManage.GetConnectionId(playerId);
            if (connectId != null)
            {
                await _hubContext.Clients.Client(connectId).SendAsync("TradeResult", result);
            }
        }
    }
}