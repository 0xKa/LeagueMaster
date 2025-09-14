using LeagueMaster.Application.DTOs.Matches;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _service;
        public MatchesController(IMatchService service) => _service = service;

        [HttpGet(Name = "GetAllMatches")]
        [ProducesResponseType(typeof(IEnumerable<MatchDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var matches = (await _service.GetAllAsync()).ToList();

            if (matches == null || matches.Count == 0)
                return NotFound("No Matches found in the system");

            return Ok(matches);
        }

        [HttpGet("{id:int}", Name = "GetMatchById")]
        [ProducesResponseType(typeof(MatchDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _service.GetByIdAsync(id);
            
            if (match == null) 
                return NotFound($"Match with ID {id} not found");
            
            return Ok(match);
        }

        [HttpGet("team/{teamId:int}", Name = "GetMatchesByTeamId")]
        [ProducesResponseType(typeof(IEnumerable<MatchDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTeamId(int teamId)
        {
            var matches = (await _service.GetByTeamIdAsync(teamId)).ToList();

            if (matches == null || matches.Count == 0)
                return NotFound($"No Matches found for team with ID {teamId}");

            return Ok(matches);
        }

        [HttpGet("date-range", Name = "GetMatchesByDateRange")]
        [ProducesResponseType(typeof(IEnumerable<MatchDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
                return BadRequest("Start date cannot be greater than end date");

            var matches = (await _service.GetByDateRangeAsync(startDate, endDate)).ToList();

            if (matches == null || matches.Count == 0)
                return NotFound($"No Matches found between {startDate:yyyy-MM-dd} and {endDate:yyyy-MM-dd}");

            return Ok(matches);
        }

        [HttpPost(Name = "CreateMatch")]
        [ProducesResponseType(typeof(MatchDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MatchInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            if (dto.HomeTeamId == dto.AwayTeamId)
                return BadRequest("Home team and away team cannot be the same");

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}", Name = "UpdateMatch")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] MatchInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            if (dto.HomeTeamId == dto.AwayTeamId)
                return BadRequest("Home team and away team cannot be the same");

            var updated = await _service.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"Match with ID {id} not found");
            
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteMatch")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID supplied");

            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"Match with ID {id} not found");
            
            return NoContent();
        }
    }
}