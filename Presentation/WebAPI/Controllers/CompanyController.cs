using System.Security.Claims;
using Application.Features.Company.GetAllRequests;
using Application.Features.Customer.CreateRequest;
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
}