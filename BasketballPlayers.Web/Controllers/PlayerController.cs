using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.PlayerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketballPlayers.Web.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/Player
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PlayerViewModel>>> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        // GET: api/Player/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerDetailViewModel>> GetPlayerDetails(Guid id)
        {
            try
            {
                var player = await _playerService.GetPlayerDetailsAsync(id);
                return Ok(player);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Player with ID {id} not found");
            }
        }

        // POST: api/Player
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlayerViewModel>> CreatePlayer([FromBody] PlayerCreateViewModel playerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPlayer = await _playerService.CreatePlayerAsync(playerViewModel);
            return CreatedAtAction(nameof(GetPlayerDetails), new { id = createdPlayer.Id }, createdPlayer);
        }

        // PUT: api/Player/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] PlayerUpdateViewModel playerViewModel)
        {
            if (id != playerViewModel.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _playerService.UpdatePlayerAsync(playerViewModel);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Player/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
                await _playerService.DeletePlayerAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Player with ID {id} not found");
            }
        }
    }
}
