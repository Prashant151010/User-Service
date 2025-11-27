using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using User.Application.Services.Auth.Commands;
using User.Domain.DTOs;

namespace User.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixedLimit")]
    public class AuthController(IMediator mediator, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<AuthController> _logger = logger;

        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] TokenDto dto)
        {
            if (dto == null)
            {
                _logger.LogWarning("Login attempt with null request body.");
                return BadRequest(new { message = "Request body cannot be null." });
            }

            if (string.IsNullOrWhiteSpace(dto.User) || string.IsNullOrWhiteSpace(dto.Password))
            {
                _logger.LogWarning("Login attempt with missing credentials.");
                return BadRequest(new { message = "Username and password are required." });
            }

            _logger.LogInformation("Login attempt for user: {Username}", dto.User);

            var response = await _mediator.Send(new TokenCommand(dto));

            if (response == null || response.Status == "error")
            {
                _logger.LogWarning("Login failed for user: {Username}", dto.User);
                return Unauthorized(new { message = "Invalid username or password." });
            }

            _logger.LogInformation("User {Username} logged in successfully", dto.User);
            return Ok(response);
        }
    }
}
