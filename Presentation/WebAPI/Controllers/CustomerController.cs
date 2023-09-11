using System.Security.Claims;
using Application.Features.Customer.CreateRequest;
using Application.Features.Customer.CreateReservation;
using Application.Features.Customer.GetRequestsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
    
[Authorize(Policy = "CustomerPolicy")]
[Route("api/customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("request/create")]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();
        
        request.UserId = userId;

        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("request/get_by_id")]
    public async Task<IActionResult> GetRequestsById()
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();

        var request = new GetRequestsByIdRequest
        {
            UserId = userId
        };

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
    
    [HttpPost("reservation/create")]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}