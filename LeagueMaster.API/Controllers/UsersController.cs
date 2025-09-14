using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication for all endpoints
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = (await _userService.GetAllAsync()).ToList();

            if (users == null || users.Count == 0)
                return NotFound("No users found in the system");

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            
            if (user == null) 
                return NotFound($"User with ID {id} not found");
            
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            
            if (user == null) 
                return NotFound($"User with username '{username}' not found");
            
            return Ok(user);
        }

        [HttpGet("profile")]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var id))
                return BadRequest("Invalid user ID in token");

            var user = await _userService.GetByIdAsync(id);
            
            if (user == null) 
                return NotFound("User profile not found");
            
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            // Check if user already exists
            if (await _userService.ExistsAsync(dto.Username))
                return BadRequest("Username already exists");

            var created = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var updated = await _userService.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound($"User with ID {id} not found");
            
            return NoContent();
        }

        [HttpPut("profile")]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UserInputDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var id))
                return BadRequest("Invalid user ID in token");

            // Regular users can't change their own role
            if (User.IsInRole("User") && !User.IsInRole("Admin"))
            {
                var currentUser = await _userService.GetByIdAsync(id);
                if (currentUser != null && dto.Role.ToString() != currentUser.Role)
                {
                    return Forbid("You cannot change your own role");
                }
            }

            var updated = await _userService.UpdateAsync(id, dto);
            
            if (!updated) 
                return NotFound("User profile not found");
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID supplied");

            // Prevent admin from deleting themselves
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == id.ToString())
                return BadRequest("You cannot delete your own account");

            var deleted = await _userService.DeleteAsync(id);
            
            if (!deleted) 
                return NotFound($"User with ID {id} not found");
            
            return NoContent();
        }

        [HttpGet("exists/{username}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckUserExists(string username)
        {
            var exists = await _userService.ExistsAsync(username);
            return Ok(new { username, exists });
        }
    }
}