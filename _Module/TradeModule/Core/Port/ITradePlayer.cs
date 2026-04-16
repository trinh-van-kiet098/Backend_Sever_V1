using Backend_Game._Module.TradeModule.Core.Entities;

namespace Backend_Game._Module.TradeModule.Core.Port
{
    public interface ITradeService
    {
        Task SendTradeRequest(Trade trade);
        Task SendTradeResponse(string tradeId, string playerId, string response);
    }
}