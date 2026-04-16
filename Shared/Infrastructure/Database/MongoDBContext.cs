
using Backend_Game.Shared.Core.Ports;
using MongoDB.Driver;
using System.Linq.Expressions;
namespace Backend_Game.Shared.Infrastructure.Database
{
    public class MongoDBContext : IDatabase
    {
        private readonly IMongoDatabase _db;
        public MongoDBContext(IMongoDatabase database)
        {
            _db = database;
        }

        public async Task AddAsync<T>(string collectionName, T entity)
        {
            await _db.GetCollection<T>(collectionName).InsertOneAsync(entity);
        }

        public async Task<T?> FindAsync<T>(string collectionName, Expression<Func<T, bool>> predicate)
        {
            return await _db.GetCollection<T>(collectionName).Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync<T>(string collectionName, Expression<Func<T, bool>>? predicate = null)
        {
            var collection = _db.GetCollection<T>(collectionName);
            if (predicate == null) return await collection.Find(_ => true).ToListAsync();
            return await collection.Find(predicate).ToListAsync();
        }

        public async Task UpdateAsync<T>(string collectionName, string id, T entity)
        {
            // Trong MongoDB, khóa chính thường map với field "Id" hoặc "_id"
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _db.GetCollection<T>(collectionName).ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync<T>(string collectionName, string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _db.GetCollection<T>(collectionName).DeleteOneAsync(filter);
        }
        

    }

}