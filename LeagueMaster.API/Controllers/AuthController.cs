using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LeagueMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInputDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.RegisterAsync(userDto);
            
            if (user == null)
                return BadRequest("Username or email already exists");

            return Ok(new { message = "User registered successfully", userId = user.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([Required] string username,[Required] string password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(username, password);
            
            if (result == null)
                return Unauthorized("Invalid credentials");

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RefreshTokenAsync(request);
            
            if (result == null)
                return Unauthorized("Invalid refresh token");

            return Ok(result);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("authentication-only")]
        public IActionResult AuthenticationOnly()
        {
            // This endpoint can only be accessed by authenticated users
            return Ok("You are authenticated");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnly()
        {
            // This endpoint can only be accessed by users with the "Admin" role
            return Ok("You are an admin");
        }




    }
}