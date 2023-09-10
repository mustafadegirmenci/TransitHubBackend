using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Features.Authorization.Register;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using WebAPI.Models.Authentication;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;    
    
    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
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

    // [HttpPost("login")]
    // public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    // {
    //      var user = await _userManager.FindByNameAsync(model.Username);
    //     
    //      if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
    //      {
    //          return Unauthorized("Invalid username or password.");
    //      }
    //
    //      var token = GenerateJwtToken(user);
    //
    //      return Ok(new { Token = token });
    // }
    //
    // private string GenerateJwtToken(User user)
    // {
    //     var claims = new[]
    //     {
    //         new Claim(JwtRegisteredClaimNames.Sub, user.Username),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //     };
    //
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //     var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));
    //
    //     var token = new JwtSecurityToken(
    //         _configuration["Jwt:Issuer"],
    //         _configuration["Jwt:Issuer"],
    //         claims,
    //         expires: expires,
    //         signingCredentials: creds
    //     );
    //
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}