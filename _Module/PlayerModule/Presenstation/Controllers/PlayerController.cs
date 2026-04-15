using Microsoft.AspNetCore.Mvc;
using Backend_Game._Module.PlayerModule.Core.Ports;
namespace Backend_Game._Module.PlayerModule.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // Các action method ở đây, ví dụ:
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllAsync();
            return Ok("hello, players!"+players.Count);
        }
    }
}