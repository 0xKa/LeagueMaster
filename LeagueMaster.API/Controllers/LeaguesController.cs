using LeagueMaster.Application.DTOs;
using LeagueMaster.Application.DTOs.Leagues;
using LeagueMaster.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _service;
        public LeaguesController(ILeagueService service) => _service = service;

        [HttpGet(Name = "GetAllLeagues")]
        [ProducesResponseType(typeof(IEnumerable<LeagueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var leagues = (await _service.GetAllAsync()).ToList();

            if (leagues == null || leagues.Count == 0)
                return NotFound("No Leagues found in the system");

            return Ok(leagues);
        }

        [HttpGet("{id:int}", Name = "GetLeagueById")]
        [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var league = await _service.GetByIdAsync(id);
            
            if (league == null) 
                return NotFound($"League with ID {id} not found");
            
            return Ok(league);
        }

        [HttpPost(Name = "CreateLeague")]
        [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateLeagueDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}", Name = "UpdateLeague")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLeagueDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"League with ID {id} not found");
            
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteLeague")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"League with ID {id} not found");
            
            return NoContent();
        }
    }
}
