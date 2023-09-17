using System.Security.Claims;
using Application.Features.Customer.Authorization.Login;
using Application.Features.Customer.Authorization.Register;
using Application.Features.Customer.CreateRequest;
using Application.Features.Customer.CreateReservation;
using Application.Features.Customer.GetCustomerInfo;
using Application.Features.Customer.GetOffers;
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
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCustomerRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            
            if (response.Token is null)
            {
                return Problem();
            }
            
            return Ok(new
            {
                Token = response.Token, 
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Registration failed.", Error = ex.Message });
        }
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCustomerRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);

            if (response.Token is null)
            {
                return Problem();
            }
            
            return Ok(new
            {
                Token = response.Token
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Login failed.", Error = ex.Message });
        }
    }
  
    [HttpGet("get")]
    public async Task<IActionResult> GetCustomerInfo()
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var companyId)) return BadRequest();

        var request = new GetCustomerInfoRequest()
        {
            CustomerId = companyId
        };
        
        try
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
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
    
    [HttpGet("request/get")]
    public async Task<IActionResult> GetRequests()
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
            var requests = await _mediator.Send(request);
            return Ok(requests.Requests);
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpGet("offer/get")]
    public async Task<IActionResult> GetOffers([FromBody] GetOffersRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out _)) return BadRequest();

        try
        {
            var offers = await _mediator.Send(request);
            return Ok(offers.Offers);
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