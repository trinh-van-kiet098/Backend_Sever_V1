
using Backend_Game._Module.TradeModule.Core.Entities;
using Backend_Game._Module.TradeModule.Core.Port;
namespace Backend_Game._Module.TradeModule.Core.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly INotifycation _notifycation;
        public TradeService(ITradeRepository tradeRepository, INotifycation notifycation)
        {
            _tradeRepository = tradeRepository;
            _notifycation = notifycation;
        }
        public async Task SendTradeRequest(Trade trade)
        {
            if (trade.FromPlayerId == trade.ToPlayerId)
                throw new ArgumentException("Không thể tự giao dịch với chính mình!");
            if (trade.Quantity <= 0 && trade.GoldAmount <= 0)
                throw new ArgumentException("Giao dịch phải có ít nhất 1 vật phẩm hoặc vàng!");
            trade.Status = TradeStatus.Pending;
            trade.RequestedAt = DateTime.UtcNow;
            await _tradeRepository.AddTrade(trade);
            await _notifycation.NotifycationTrade(trade.ToPlayerId.ToString(), trade);
        }
        public async Task SendTradeResponse(string tradeId, string playerId, string response)
        {
            var trade = await _tradeRepository.GetByIdAsync(tradeId);
            if (trade == null)
            {
                throw new Exception("Giao dịch không tồn tại!");
            }
            if (trade.ToPlayerId.ToString() != playerId)
            {
                throw new UnauthorizedAccessException("Bạn không có quyền can thiệp vào giao dịch của người khác!");
            }
            if (trade.Status != TradeStatus.Pending)
            {
                throw new InvalidOperationException("Giao dịch này đã được xử lý hoặc đã hủy!");
            }
            if (response.Equals("Accepted", StringComparison.OrdinalIgnoreCase))
            {
                trade.Status = TradeStatus.Accepted;
            }
            else if (response.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
            {
                trade.Status = TradeStatus.Rejected;
            }
            else
            {
                throw new ArgumentException("Hành động không hợp lệ!");
            }

            await _tradeRepository.UpdateAsync(trade);
            string message = trade.Status == TradeStatus.Accepted
                ? "Giao dịch của bạn đã thành công!"
                : "Người nhận đã từ chối giao dịch!";
            await _notifycation.NotifycationResultTrade(trade.FromPlayerId.ToString(), message);

        }

    }
}