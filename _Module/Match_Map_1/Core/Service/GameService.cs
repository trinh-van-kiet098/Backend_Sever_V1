using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public class GameService : IGameService
    {
        private readonly IMemoryMatch _memoryMatch;

        public GameService(IMemoryMatch memoryMatch)
        {
            _memoryMatch = memoryMatch;
        }


        public void AddPlayer(string idMatch, string playerId)
        {
            var playerState = new PlayerState
            {
                Id = playerId,
                MatchId = idMatch,
                PositionX = 0,
                PositionY = 0,
                PositionZ = 0
            };
            _memoryMatch.AddPlayer(idMatch, playerState);
        }

        public IEnumerable<PlayerState> GetAllPlayerStates(string idMatch)
        {
            return _memoryMatch.GetAllPlayerStates(idMatch);
        }

        public void MovePlayer(string match, string playerId, int x, int y, int z)
        {
            _memoryMatch.MovePlayer(match, playerId, x, y, z);
        }
        public void RemovePlayer( string playerId)
        {
            _memoryMatch.RemovePlayer( playerId);
        }
        public IEnumerable<string> GetAllMatchIds()
        {
            return _memoryMatch.GetAllMatchIds();
        }

    }
}