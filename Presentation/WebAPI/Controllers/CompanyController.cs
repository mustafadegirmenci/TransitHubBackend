using System.Security.Claims;
using Application.Features.Company.AssignDriver;
using Application.Features.Company.AssignVehicle;
using Application.Features.Company.CreateDriver;
using Application.Features.Company.CreateResponse;
using Application.Features.Company.CreateTeam;
using Application.Features.Company.CreateVehicle;
using Application.Features.Company.GetAllRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
    
[Authorize(Policy = "CompanyPolicy")]
[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("request/get")]
    public async Task<IActionResult> GetAllRequests()
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null)
        {
            return Unauthorized();
        }
        
        try
        {
            var response = await _mediator.Send(new GetAllRequestsRequest());
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpPost("team/create")]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();
        
        request.CompanyId = userId;
        
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpPost("vehicle/create")]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();
        
        request.CompanyId = userId;
        
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
        
    [HttpPost("vehicle/assign")]
    public async Task<IActionResult> AssignVehicle([FromBody] AssignVehicleRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
            
    [HttpPost("driver/assign")]
    public async Task<IActionResult> AssignDriver([FromBody] AssignDriverRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpPost("driver/create")]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();
        
        request.CompanyId = userId;
        
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpPost("response/create")]
    public async Task<IActionResult> CreateResponse([FromBody] CreateResponseRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}