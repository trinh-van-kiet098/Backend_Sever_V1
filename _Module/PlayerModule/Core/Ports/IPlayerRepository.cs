using Backend_Game._Module.PlayerModule.Core.Entities;
namespace Backend_Game._Module.PlayerModule.Core.Ports
{
    public interface IPlayerRepository
    {
        Task<Player?> GetByIdAsync(Guid id);
        Task<Player?> GetByUsernameAsync(string username);
        Task CreateAsync(Player player);
        Task UpdateAsync(Player player);
        Task DeleteAsync(Guid id);
        Task<List<Player>> GetAllAsync();
    }
}