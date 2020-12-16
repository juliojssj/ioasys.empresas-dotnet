using Ioasys.Domain.AuthAggregate.Dtos;
using Ioasys.Domain.AuthAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ioasys.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login para obteção do token
        /// </summary>
        /// <response code="200"></response>
        [HttpPost("login")]
        public IActionResult LoginAdmin([FromBody] LoginDto loginDto)
        {
            var token = _authService.Login(loginDto);

            return Ok(new { token });
        }
    }
}
