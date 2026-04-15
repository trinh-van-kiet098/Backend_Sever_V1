using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.Match_Map_1.Core.Entities;

namespace Backend_Game._Module.Match_Map_1.Infra
{
    public class MemoryMatchRepository : IMemoryMatch
    {
        // 1. KHO CHÍNH: Lưu trữ danh sách phòng và người chơi
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, PlayerState>> _rooms = new();

        // 2. MỤC LỤC PHỤ (Rất quan trọng): Chuyên dùng để tra cứu xem playerId này đang ở idMatch nào
        private readonly ConcurrentDictionary<string, string> _playerToMatchLookup = new();

        public void AddPlayer(string idMatch, PlayerState playerState)
        {
            playerState.MatchId = idMatch;
            
            // Ghi vào Kho chính
            var playersInRoom = _rooms.GetOrAdd(idMatch, _ => new ConcurrentDictionary<string, PlayerState>());
            playersInRoom.TryAdd(playerState.Id, playerState);

            // Ghi vào Mục lục phụ để sau này tra cứu
            _playerToMatchLookup.TryAdd(playerState.Id, idMatch);
        }

        public IEnumerable<PlayerState> GetAllPlayerStates(string idMatch)
        {
            if (_rooms.TryGetValue(idMatch, out var playersInRoom))
            {
                return playersInRoom.Values;
            }
            return Enumerable.Empty<PlayerState>();
        }

        public void RemovePlayer(string playerId)
        {
            if (_playerToMatchLookup.TryRemove(playerId, out string? idMatch))
            {
                if (_rooms.TryGetValue(idMatch, out var playersInRoom))
                {
                    playersInRoom.TryRemove(playerId, out _);
                    if (playersInRoom.IsEmpty) 
                    {
                        _rooms.TryRemove(idMatch, out _);
                    }
                }
            }
        }

        public void MovePlayer(string idMatch, string playerId, int x, int y, int z)
        {
            if (_rooms.TryGetValue(idMatch, out var playersInRoom) &&
                playersInRoom.TryGetValue(playerId, out var playerState))
            {
                playerState.PositionX = x;
                playerState.PositionY = y;
                playerState.PositionZ = z;
            }
        }

        public void UpdatePlayerState(string idMatch, PlayerState playerState)
        {
            if (_rooms.TryGetValue(idMatch, out var playersInRoom))
            {
                playersInRoom.AddOrUpdate(playerState.Id, playerState, (key, existing) => playerState);
            }
        }
        public IEnumerable<string> GetAllMatchIds()
        {
            return _rooms.Keys;
        }
    }
}