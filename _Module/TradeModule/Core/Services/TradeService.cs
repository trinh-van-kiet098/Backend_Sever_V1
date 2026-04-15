using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.TradeModule.Core.Entities;
using Backend_Game._Module.TradeModule.Core.Port;
namespace Backend_Game._Module.TradeModule.Core.Services
{
    public class TradeService : ITradeService
    {
        private readonly IMemoryMatch memoryMatch;
        public TradeService(IMemoryMatch memoryMatch)
        {
            this.memoryMatch = memoryMatch;
        }
        public void SendTradeRequest(string fromPlayerId, string toPlayerId)
        {
            
        }
        public void SendTradeRequest(Trade trade)
        {
            
        }
        public void SendTradeResponse(Trade trade, string response)
        {
            
        }

    }
}