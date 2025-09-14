using LeagueMaster.Application.DTOs.Players;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;
        public PlayersController(IPlayerService service) => _service = service;

        [Authorize(Roles = "User,Admin")]
        [HttpGet(Name = "GetAllPlayers")]
        [ProducesResponseType(typeof(IEnumerable<PlayerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var players = (await _service.GetAllAsync()).ToList();

            if (players == null || players.Count == 0)
                return NotFound("No Players found in the system");

            return Ok(players);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id:int}", Name = "GetPlayerById")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _service.GetByIdAsync(id);
            
            if (player == null) 
                return NotFound($"Player with ID {id} not found");
            
            return Ok(player);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("team/{teamId:int}", Name = "GetPlayersByTeamId")]
        [ProducesResponseType(typeof(IEnumerable<PlayerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTeamId(int teamId)
        {
            var players = (await _service.GetByTeamIdAsync(teamId)).ToList();

            if (players == null || players.Count == 0)
                return NotFound($"No Players found for team with ID {teamId}");

            return Ok(players);
        }

        [HttpPost(Name = "CreatePlayer")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] PlayerInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}", Name = "UpdatePlayer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] PlayerInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"Player with ID {id} not found");
            
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeletePlayer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID supplied");

            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"Player with ID {id} not found");
            
            return NoContent();
        }
    }
}