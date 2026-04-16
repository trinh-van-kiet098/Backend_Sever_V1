using Backend_Game._Module.Match_Map_1.Core;
using Backend_Game._Module.Match_Map_1.Core.Entities;
using Backend_Game._Module.PlayerModule.Core.Ports;
namespace Backend_Game._Module.Match_Map_1.Core.Service
{
    public class PlayerService : IPlayerState
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<PlayerState> GetPlayerStateAsync(string idMatch, Guid playerId)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            //Summary: Tạm thời tạo PlayerState giả, sau này sẽ lấy thông 
            // tin từ player để tạo PlayerState và có thể lấy thêm như khiên, mana, damage, defense,... 
            // tùy theo thiết kế của bạn
            if (player == null) throw new InvalidOperationException("Player not found");
            return new PlayerState
            {
                Id = playerId.ToString(),
                MatchId = idMatch,
                DisplayName=player.DisplayName,
                PositionX = 2,
                PositionY = 0,
                PositionZ = 10,
                CurrentHealth = 100,
                MaxHealth = 100,
                CurrentMana = 50,
                MaxMana = 50,
                Damage = 10,
            };
        }
    }
}