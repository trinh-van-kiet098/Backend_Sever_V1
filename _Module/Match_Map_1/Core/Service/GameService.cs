using Backend_Game._Module.Match_Map_1.Core.Entities;
using Backend_Game._Module.PlayerModule.Core.Ports;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public class GameService : IGameService
    {
        private readonly IMemoryMatch _memoryMatch;
        private readonly IPlayerState _playerState;
        public GameService(IMemoryMatch memoryMatch, IPlayerState playerState)
        {
            _memoryMatch = memoryMatch;
            _playerState = playerState;
        }


        public async Task AddPlayer(string idMatch, string playerId)
        {
            //Khởi tạo PlayerState
            var playerState = await _playerState.GetPlayerStateAsync(idMatch, Guid.Parse(playerId));
            if (playerState == null)
                throw new InvalidOperationException("Player not found");
            
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