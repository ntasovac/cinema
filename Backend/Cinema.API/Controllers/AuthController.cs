using Cinema.Application.DTOs;
using Cinema.Application.IServices;
using Cinema.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDTO request)
        {
            var user = await _authService.RegisterAsync(request);
            if(user is null) 
                return BadRequest("Username already exists");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login([FromBody] LoginUserDTO request) 
        {
            var result = await _authService.LoginAsync(request);
            if(result is null) 
                return BadRequest("Invalid username or password");
            
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO request) 
        {
            var result = await _authService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token");
            return Ok(result);
        }

    }
}
