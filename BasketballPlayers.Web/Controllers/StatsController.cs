using BasketballPlayers.Application.Contracts;
using BasketballPlayers.Application.ViewModels.StatsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketballPlayers.Web.Controllers
{
    [ApiController]
    [Route("api/stats")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        // GET: api/Stats/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatsViewModel>> GetStatsById(Guid id)
        {
            try
            {
                var stats = await _statsService.GetStatsByIdAsync(id);
                if (stats == null)
                {
                    return NotFound($"Stats with ID {id} not found");
                }
                return Ok(stats);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Stats with ID {id} not found");
            }
        }

        // GET: api/Stats/player/{playerId}
        [HttpGet("player/{playerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatsViewModel>> GetStatsByPlayerId(Guid playerId)
        {
            try
            {
                var stats = await _statsService.GetStatsByPlayerIdAsync(playerId);
                if (stats == null)
                {
                    return NotFound($"Stats for player with ID {playerId} not found");
                }
                return Ok(stats);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Stats for player with ID {playerId} not found");
            }
        }

        // POST: api/Stats
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StatsViewModel>> CreateStats([FromBody] StatsCreateViewModel statsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdStats = await _statsService.CreateStatsAsync(statsViewModel);
            return CreatedAtAction(nameof(GetStatsById), new { id = createdStats.Id }, createdStats);
        }

        // PUT: api/Stats/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStats(Guid id, [FromBody] StatsUpdateViewModel statsViewModel)
        {
            if (id != statsViewModel.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _statsService.UpdateStatsAsync(statsViewModel);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
