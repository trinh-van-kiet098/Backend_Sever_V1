using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Backend_Game._Module.TradeModule.Core.Entities;

namespace Backend_Game.Shared.Infrastructure.Database
{
    public static class MongoDbConfig
    {
        public static void RegisterMappings()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Trade)))
            {
                BsonClassMap.RegisterClassMap<Trade>(cm =>
                {
                    cm.AutoMap();
                    cm.MapMember(c => c.ToPlayerId);
                    cm.MapMember(c => c.FromPlayerId);
                    cm.MapProperty(c => c.Status)
                      .SetSerializer(new EnumSerializer<TradeStatus>(BsonType.String));
                });
            }
        }
    }
}