using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend_Game._Module.TradeModule.Core.Entities
{
    public enum TradeStatus
    {
        Pending,
        Accepted,
        Rejected,
        Canceled
    }
    public class Trade
    {
        [BsonId]
        public string Id { get; set; } =string.Empty;
        public string FromPlayerId { get; set; } =string.Empty;
        public string ToPlayerId { get; set; } =string.Empty;
        public string InventoryId { get; set; } =string.Empty;
        public int Quantity { get; set; }
        public int GoldAmount { get; set; }
        public TradeStatus Status;
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}