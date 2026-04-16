using Backend_Game._Module.PlayerModule.Core.Entities;
namespace Backend_Game._Module.PlayerModule.Core.Ports
{
    public interface IPlayerService
    {
        Task AddPlayer(string playerId);
        Task<Player?> GetPlayerAsync(string playerId);

    }
}