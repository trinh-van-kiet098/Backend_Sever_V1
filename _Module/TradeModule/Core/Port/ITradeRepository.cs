using Backend_Game._Module.TradeModule.Core.Entities;
namespace Backend_Game._Module.TradeModule.Core.Port
{
    public interface ITradeRepository
    {
        Task AddTrade(Trade trade);
        Task<Trade> GetByIdAsync(string tradeId);
        Task<IEnumerable<Trade>> GetPendingTradesForPlayerAsync(string playerId);
        Task UpdateAsync(Trade trade);
    }
}