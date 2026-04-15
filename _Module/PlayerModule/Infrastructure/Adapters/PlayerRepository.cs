using Backend_Game._Module.PlayerModule.Core.Entities;
using Backend_Game._Module.PlayerModule.Core.Ports;
using Backend_Game.Shared.Core.Ports;
namespace Backend_Game._Module.PlayerModule.Infrastructure.Adapters
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDatabase _database;
        private const string CollectionName = "Players";

        public PlayerRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Player player)
        {
            await _database.AddAsync(CollectionName, player);
        }

        public async Task<Player?> FindByIdAsync(Guid id)
        {
            return await _database.FindAsync<Player>(CollectionName, p => p.Id == id);
        }

        /// <summary>
        /// Lấy tất cả người chơi. Trong thực tế, bạn có thể muốn thêm phân trang hoặc các tiêu chí lọc khác để tránh trả về quá nhiều dữ liệu cùng lúc.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Player>> GetAllAsync()
        {
            return await _database.GetListAsync<Player>(CollectionName);
        }
        public async Task UpdateAsync(Player player)
        {
            await _database.UpdateAsync(CollectionName, player.Id, player);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _database.DeleteAsync<Player>(CollectionName, id);
        }
        /// <summary>
        /// Phương thức này cho phép tạo nhiều người chơi cùng lúc. Điều này có thể hữu ích khi bạn muốn khởi tạo một số lượng lớn người chơi hoặc thực hiện các thao tác batch. Tuy nhiên, hãy cẩn thận khi sử dụng phương thức này để tránh việc tạo quá nhiều người chơi cùng lúc, điều này có thể
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>

        public async Task<Player?> GetByIdAsync(Guid id)
        {
            return await _database.FindAsync<Player>(CollectionName, p => p.Id == id);
        }
        public async Task<Player?> GetByUsernameAsync(string username)
        {
            return await _database.FindAsync<Player>(CollectionName, p => p.Username == username);
        }
        public async Task CreateAsync(Player player)
        {
            await _database.AddAsync(CollectionName, player);
        }
    }

}