using Application.Features.Authorization.Login;
using Application.Features.Authorization.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return Ok(new
            {
                UserId = response.UserId, 
                Message = response.Message
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Registration failed.", Error = ex.Message });
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            
            if (response.LoginSucceeded)
            {
                return Ok(new
                {
                    Token = response.Token,
                    Message = "Login successful"
                });
            }
            else
            {
                return Unauthorized(new { Message = "Login failed", Error = "Invalid credentials" });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Login failed.", Error = ex.Message });
        }
    }
}