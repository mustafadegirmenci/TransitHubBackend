using System.Security.Claims;
using Application.Features.Common.GetInfoOfCompany;
using Application.Features.Company.Authorization.Login;
using Application.Features.Company.Authorization.Register;
using Application.Features.Company.CreateDriver;
using Application.Features.Company.CreateResponse;
using Application.Features.Company.CreateVehicle;
using Application.Features.Company.GetAllRequests;
using Application.Features.Company.GetCompanyInfo;
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
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCompanyRequest request)
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
    public async Task<IActionResult> Login([FromBody] LoginCompanyRequest request)
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
            return BadRequest(new { Message = "Login failed.", Error = ex.Message });
        }
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
            return Ok(response.AllRequests);
        }
        catch
        {
            return BadRequest();
        }
    }
  
    [HttpGet("getinfowithoutcompanyid")]
    public async Task<IActionResult> GetCompanyInfo()
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var companyId)) return BadRequest();

        var request = new GetInfoOfCompanyRequest
        {
            CompanyId = companyId
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

    [HttpPost("offer/create")]
    public async Task<IActionResult> CreateOffer([FromBody] CreateOfferRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var companyId)) return BadRequest();

        request.CompanyId = companyId;
        
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
    
    [AllowAnonymous]
    [HttpPost("driver/create")]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest request)
    {
        var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim is null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var companyId)) return BadRequest();

        request.CompanyId = companyId;
        
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
        if (!int.TryParse(userIdClaim, out var companyId)) return BadRequest();

        request.CompanyId = companyId;
        
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