namespace Backend_Game._Module.TradeModule.Core.Entities
{
    public class Trade
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FromPlayerId { get; set; } = Guid.Empty;
        public Guid ToPlayerId { get; set; } = Guid.Empty;
        public Guid id_inventory_item { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
        public int goldAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}