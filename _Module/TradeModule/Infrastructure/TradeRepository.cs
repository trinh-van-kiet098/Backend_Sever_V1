using Backend_Game._Module.TradeModule.Core.Entities;
using Backend_Game._Module.TradeModule.Core.Port;
using Backend_Game.Shared.Core.Ports;

namespace Backend_Game._Module.TradeModule.Infrastructure
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IDatabase _database;
        private const string Collection = "Trades";

        public TradeRepository(IDatabase database)
        {
            _database = database;
        }
        public async Task AddTrade(Trade trade)
        {
            await _database.AddAsync(Collection, trade);
        }
        public async Task<Trade> GetByIdAsync(string tradeId)
        {
            return await _database.FindAsync<Trade>(Collection, t => t.Id.ToString() == tradeId);
        }
        public async Task<IEnumerable<Trade>> GetPendingTradesForPlayerAsync(string playerId)
        {
            return await _database.GetListAsync<Trade>(Collection,
                t => t.ToPlayerId == playerId && t.Status == TradeStatus.Pending);
        }

        public async Task UpdateAsync(Trade trade)
        {
            await _database.UpdateAsync(Collection, trade.Id, trade);
        }

    }
}