using Backend_Game._Module.Match_Map_1.Core;
using Microsoft.AspNetCore.SignalR;
using Backend_Game._Module.Match_Map_1.Core.Entities;
using Backend_Game._Module.TradeModule.Core.Port;
using System.Runtime.CompilerServices;
using Backend_Game._Module.TradeModule.Core.Entities;
namespace Backend_Game.Shared.Infrastructure.GameHub
{
    public class GameHub : Hub
    {
        private readonly IGameService _gameService;
        private readonly IConnectionManage _connectionManage;
        private readonly ITradeService _tradeService;
        public GameHub(IGameService gameService, IConnectionManage connectionManage, ITradeService tradeService)
        {
            _gameService = gameService;
            _connectionManage = connectionManage;
            _tradeService = tradeService;
        }
        public void SendPosition(string matchId, int x, int y, int z)
        {
            string connectionId = Context.ConnectionId;
            string playerId = _connectionManage.GetPlayerId(connectionId);
            if (playerId != null)
            {
                _gameService.MovePlayer(matchId, playerId, x, y, z);
                var playerStates = _gameService.GetAllPlayerStates(matchId);
                Clients.Group(matchId).SendAsync("UpdatePlayerPositions", playerStates);
            }
        }
        public async Task JoinMatch(string matchId, Guid idPlayer)
        {
            string connectionId = Context.ConnectionId;
            string playerIdString = idPlayer.ToString();
            _connectionManage.AddMapping(connectionId, idPlayer);
            _gameService.AddPlayer(matchId, playerIdString);
            await Groups.AddToGroupAsync(connectionId, matchId);
            var allPlayers = _gameService.GetAllPlayerStates(matchId);
            await Clients.Caller.SendAsync("MatchStateSync", allPlayers);
            await Clients.Group(matchId).SendAsync("PlayerJoined", playerIdString);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string connectionId = Context.ConnectionId;
            string? playerId = _connectionManage.GetPlayerId(connectionId);
            if (!string.IsNullOrEmpty(playerId))
            {
                _gameService.RemovePlayer(playerId);
            }
            _connectionManage.RemoveMapping(connectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task RequestTrade(string targetPlayerId, int goldAmount, int quantity)
        {
            string senderConnectionId = Context.ConnectionId;
            string? senderPlayerId = _connectionManage.GetPlayerId(senderConnectionId);

            if (string.IsNullOrEmpty(senderPlayerId))
            {
                await Clients.Caller.SendAsync("Error", "Không tìm thấy thông tin người chơi của bạn.");
                return;
            }
            try
            {
                // 1. Tạo object Trade
                var newTrade = new Trade
                {
                    Id = Guid.NewGuid().ToString(), // Khởi tạo ID giao dịch
                    FromPlayerId = senderPlayerId,
                    ToPlayerId = targetPlayerId,
                    GoldAmount = goldAmount,
                    Quantity = quantity,
                    // ItemId = ... (thêm nếu schema của bạn có)
                };

                // 2. Gọi service xử lý logic và lưu DB
                // Hàm này sẽ tự set status = Pending và ném Exception nếu data không hợp lệ
                await _tradeService.SendTradeRequest(newTrade);

                // 3. Thông báo cho người nhận qua SignalR
                string? targetConnectionId = _connectionManage.GetConnectionId(targetPlayerId);
                if (!string.IsNullOrEmpty(targetConnectionId))
                {
                    // Quan trọng: Gửi kèm newTrade.Id để FE dùng cho hàm ResponseTrade sau này
                    await Clients.Client(targetConnectionId).SendAsync("RequestTrade", senderPlayerId, newTrade.Id);
                }
            }
            catch (ArgumentException ex)
            {
                // Bắt lỗi từ TradeService (ví dụ: tự giao dịch, số lượng <= 0) và báo về cho người GỬI
                await Clients.Caller.SendAsync("TradeError", ex.Message);
            }
            catch (Exception ex)
            {
                // Lỗi hệ thống chung
                await Clients.Caller.SendAsync("TradeError", "Lỗi: " + ex.Message + " | " + ex.InnerException?.Message);
            }
        }
        public async Task ResponseTrade(string targetPlayerId, bool isAccep)
        {
            string senderConnectionId = Context.ConnectionId;

        }
    }
}