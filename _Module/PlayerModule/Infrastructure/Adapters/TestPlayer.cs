using Backend_Game._Module.PlayerModule.Core.Ports;
using Backend_Game._Module.PlayerModule.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Infra
{
    public class TestPlayer : IPlayerRepository
    {
        public async Task<Player?> GetByIdAsync(Guid id)
        {
            return new Player
            {
                Id = id,
                Username = "testuser",
                PasswordHash = "hashedpassword",
                DisplayName = "Test User",
                Level = 1,
                CreatedAt = DateTime.UtcNow
            };
        }
        public async Task<Player?> GetByUsernameAsync(string username)
        {
            return new Player
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = "hashedpassword",
                DisplayName = "Test User",
                Level = 1,
                CreatedAt = DateTime.UtcNow
            };
        }
        public async Task CreateAsync(Player player)
        {
            // Implementation for creating a player
        }
        public async Task UpdateAsync(Player player)
        {
            // Implementation for updating a player
        }
        public async Task DeleteAsync(Guid id)
        {
            // Implementation for deleting a player
        }
        public async Task<List<Player>> GetAllAsync()
        {
            // Implementation for getting all players
            return new List<Player>();
        }
    }
}