
namespace Backend_Game._Module.Match_Map_1.Core.Entities
{
    public class PlayerState
    {
        public string MatchId { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        //Tọa độ
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        //Máu, khiên, mana,..
        public float CurrentHealth { get; set; }
        public float MaxHealth { get; set; }
        public float CurrentMana { get; set; }
        public float MaxMana { get; set; }
        public float Damage { get; set; }
        public float Defense { get; set; }
        //Trạng thái khác: đang chạy, đang đứng, đang tấn công, đang chết,..
        public string Status { get; set; } = "Idle";
    }
}