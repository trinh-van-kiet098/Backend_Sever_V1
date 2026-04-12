
using System.Collections.Concurrent;
using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Infra
{
    public class MemoryMatchRepository : IMemoryMatch
    {
        private readonly ConcurrentDictionary<string, PlayerState> _playerStates = new ConcurrentDictionary<string, PlayerState>();

        public IEnumerable<PlayerState> GetAllPlayerStates()
        {
            return _playerStates.Values;
        }

        public void UpdatePlayerState(PlayerState playerState)
        {
            _playerStates[playerState.Id] = playerState;
        }

        public void RemovePlayer(string playerId)
        {
            _playerStates.TryRemove(playerId, out _);
        }
        public void AddPlayer(PlayerState playerState)
        {
            _playerStates.TryAdd(playerState.Id, playerState);
        }

        public void MovePlayer(string match, string playerId, int x, int y, int z)
        {
            if (_playerStates.TryGetValue(playerId, out var playerState))
            {
                playerState.PositionX = x;
                playerState.PositionY = y;
                playerState.PositionZ = z;
                _playerStates[playerId] = playerState;
            }
        }
    }
}