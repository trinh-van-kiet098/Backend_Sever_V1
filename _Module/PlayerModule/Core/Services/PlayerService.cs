using Backend_Game._Module.PlayerModule.Core.Entities;
using Backend_Game._Module.PlayerModule.Core.Ports;
namespace Backend_Game._Module.PlayerModule.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddPlayer(string playerId)
        {
            var player = new Player
            {
                Id = Guid.Parse(playerId),
                Username = $"Player_{playerId.Substring(0, 5)}",
            };
            await _playerRepository.CreateAsync(player);
        }

        public async Task<Player?> GetPlayerAsync(string playerId)
        {
            return await _playerRepository.GetByIdAsync(Guid.Parse(playerId));
        }

    }
}