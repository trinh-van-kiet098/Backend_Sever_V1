using System.Collections.Concurrent;
using Backend_Game._Module.Match_Map_1.Core;
namespace Backend_Game._Module.Match_Map_1.Infra
{
    public class ConnectionManage : IConnectionManage
    {
        private readonly ConcurrentDictionary<string, Guid> _connectionToPlayerMap = new();
        private readonly ConcurrentDictionary<Guid, string> _playerToConnectionMap = new();
        public void AddMapping(string connectionId, Guid playerId)
        {
            if(_playerToConnectionMap.TryGetValue(playerId, out string existingConnectionId))
            {
                _connectionToPlayerMap.TryRemove(existingConnectionId, out _);
            }
            _connectionToPlayerMap[connectionId] = playerId;
            _playerToConnectionMap[playerId] = connectionId;

        }
        public string GetPlayerId(string connectionId)
        {
            if (_connectionToPlayerMap.TryGetValue(connectionId, out Guid playerId))
            {
                return playerId.ToString();
            }
            return null;
        }
        public string GetConnectionId(string playerId)
        {
            if (Guid.TryParse(playerId, out Guid playerGuid) && _playerToConnectionMap.TryGetValue(playerGuid, out string connectionId))
            {
                return connectionId;
            }
            return null;
        }
        public void RemoveMapping(string connectionId)
        {
            if(_connectionToPlayerMap.TryRemove(connectionId, out Guid playerId))
            {
                _playerToConnectionMap.TryRemove(playerId, out _);
            }
        }
    }
}