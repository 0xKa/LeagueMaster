using LeagueMaster.Application.DTOs.User;
using LeagueMaster.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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


        /*
         * To test role-based authorization, you can use the following endpoints.
         * add key with value as follwing:
         * Authorization: Bearer <access token>
         */

        [Authorize(Roles = "User,Admin")]
        [HttpGet("authentication-only")]
        public IActionResult AuthenticationOnly()
        {
            // ASP.NET automatically checks if user has "Admin" role claim
            var userName = User.Identity?.Name; 
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;       

            return Ok($"Hello {userName}, You are a User.\nYour ID is {userId}\nEmail: {userEmail}");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnly()
        {
            var userName = User.Identity?.Name;        
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;      

            return Ok($"Hello {userName}, You are an Admin.\nYour ID is {userId}\nEmail: {userEmail}");
        }


    }
}