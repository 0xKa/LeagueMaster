using LeagueMaster.Application.DTOs.Coaches;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachesController : ControllerBase
    {
        private readonly ICoachService _service;
        public CoachesController(ICoachService service) => _service = service;

        [Authorize(Roles = "User,Admin")]
        [HttpGet(Name = "GetAllCoaches")]
        [ProducesResponseType(typeof(IEnumerable<CoachDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var coaches = (await _service.GetAllAsync()).ToList();

            if (coaches == null || coaches.Count == 0)
                return NotFound("No Coaches found in the system");

            return Ok(coaches);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id:int}", Name = "GetCoachById")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var coach = await _service.GetByIdAsync(id);
            
            if (coach == null) 
                return NotFound($"Coach with ID {id} not found");
            
            return Ok(coach);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("team/{teamId:int}", Name = "GetCoachByTeamId")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTeamId(int teamId)
        {
            var coach = await _service.GetByTeamIdAsync(teamId);

            if (coach == null)
                return NotFound($"No Coach found for team with ID {teamId}");

            return Ok(coach);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateCoach")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CoachInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}", Name = "UpdateCoach")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CoachInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"Coach with ID {id} not found");
            
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}", Name = "DeleteCoach")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID supplied");

            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"Coach with ID {id} not found");
            
            return NoContent();
        }
    }
}