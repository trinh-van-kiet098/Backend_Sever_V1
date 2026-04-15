using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public interface IGameService
    {
        void MovePlayer(string match, string playerId, int x, int y, int z);
        void AddPlayer(string idMatch, string playerId);
        IEnumerable<PlayerState> GetAllPlayerStates(string idMatch);
        void RemovePlayer(string playerId);
        IEnumerable<string> GetAllMatchIds();
    }
}