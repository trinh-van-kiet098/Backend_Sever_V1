using System.Runtime.InteropServices;

namespace Backend_Game._Module.Match_Map_1.Core.Entities
{
    public class PlayerState
    {
        public string Id { get; set; }
        public int Health { get; set; }
        public int Ammo { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }
    }
}