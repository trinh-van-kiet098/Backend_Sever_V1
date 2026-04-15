using Backend_Game._Module.TradeModule.Core.Entities;

namespace Backend_Game._Module.TradeModule.Core.Port
{
    public interface ITradeService
    {
        void SendTradeRequest(Trade trade);
        void SendTradeResponse(Trade trade, string response); // response: "Accepted" or "Rejected"
        void SendTradeRequest(string fromPlayerId, string toPlayerId);
    }
}