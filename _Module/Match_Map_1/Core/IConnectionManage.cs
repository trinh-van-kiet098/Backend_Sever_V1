namespace Backend_Game._Module.Match_Map_1.Core
{
    public interface IConnectionManage
    {
        void AddMapping(string matchId, Guid playerId);
        string GetPlayerId(string connectionId);
        string GetConnectionId(string playerId);
        void RemoveMapping(string connectionId);
    }
}