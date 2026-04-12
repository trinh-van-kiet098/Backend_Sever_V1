using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public interface IMemoryMatch
    {
        IEnumerable<PlayerState> GetAllPlayerStates();
        void UpdatePlayerState(PlayerState playerState);
        void RemovePlayer(string playerId);
        void AddPlayer(PlayerState playerState);
        void MovePlayer(string match,string playerId, int x, int y, int z);
    }
}