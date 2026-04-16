using Backend_Game._Module.TradeModule.Core.Entities;

namespace Backend_Game._Module.TradeModule.Core.Port
{
    public interface INotifycation
    {
        Task NotifycationTrade(string playerId, Trade trade);
        Task NotifycationResultTrade(string playerId, string trade);
    }
}