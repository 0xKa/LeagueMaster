using LeagueMaster.Application.DTOs.Team;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;
        public TeamsController(ITeamService service) => _service = service;

        [HttpGet(Name = "GetAllTeams")]
        [ProducesResponseType(typeof(IEnumerable<TeamDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var teams = (await _service.GetAllAsync()).ToList();

            if (teams == null || teams.Count == 0)
                return NotFound("No Teams found in the system");

            return Ok(teams);
        }

        [HttpGet("{id:int}", Name = "GetTeamById")]
        [ProducesResponseType(typeof(TeamDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _service.GetByIdAsync(id);
            
            if (team == null) 
                return NotFound($"Team with ID {id} not found");
            
            return Ok(team);
        }

        [HttpPost(Name = "CreateTeam")]
        [ProducesResponseType(typeof(TeamDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TeamInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}", Name = "UpdateTeam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] TeamInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"Team with ID {id} not found");
            
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteTeam")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID supplied");

            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"Team with ID {id} not found");
            
            return NoContent();
        }
    }
}
