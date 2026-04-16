using Backend_Game._Module.Match_Map_1.Core.Entities;
namespace Backend_Game._Module.Match_Map_1.Core
{
    public interface IPlayerState
    {
        Task<PlayerState> GetPlayerStateAsync(string idMatch, Guid playerId);
    }
}