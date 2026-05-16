using Microsoft.AspNetCore.Mvc;
using Dtos;
using Services.Interfaces;

namespace CineReserve.Controllers
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

        // =========================
        // REGISTER
        // =========================
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _authService.Register(dto);

            return Ok(new
            {
                message = "User Registered Successfully",
                id = user.Id,
                username = user.Username,
                role = user.Role
            });
        }

        // =========================
        // LOGIN
        // =========================
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.Login(dto);

            return Ok(new
            {
                token = token
            });
        }
    }
}