using System.Security.Claims;
using Application.Features.Customer.CreateRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize(Policy = "CustomerPolicy")]
    [HttpPost("request/create")]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null)
        {
            return Unauthorized();
        }
        
        if (int.TryParse(userIdClaim, out var userId))
        {
            request.UserId = userId;
        }
        else
        {
            return BadRequest();
        }

        var response = await _mediator.Send(request);

        if (response.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return BadRequest(response.Message);
        }
    }
}