using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public interface IMemoryMatch
    {
        IEnumerable<PlayerState> GetAllPlayerStates(string idMatch);
        void UpdatePlayerState(string idMatch, PlayerState playerState);
        void RemovePlayer(string playerId);
        void AddPlayer(string idMatch, PlayerState playerState);
        void MovePlayer(string idMatch, string playerId, int x, int y, int z);
        IEnumerable<string> GetAllMatchIds();
    }
}