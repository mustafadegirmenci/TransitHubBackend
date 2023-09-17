using System.Security.Claims;
using Application.Features.Common.GetAllDriversOfCompany;
using Application.Features.Common.GetAllMessagesOfAnOffer;
using Application.Features.Common.GetAllVehiclesOfCompany;
using Application.Features.Common.GetDriverInfo;
using Application.Features.Common.GetInfoOfCompany;
using Application.Features.Common.GetMessageInfo;
using Application.Features.Common.GetOfferInfo;
using Application.Features.Common.GetVehicleInfo;
using Application.Features.Company.CreateMessage;
using Application.Features.Company.GetCompanyInfo;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/common")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CommonController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpGet("driver/get/{driverId}")]
    public async Task<IActionResult> GetDriverInfo(int driverId)
    {
        try
        {
            var response = await _mediator.Send(new GetDriverInfoRequest { DriverId = driverId });
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
    }    
    
    [AllowAnonymous]
    [HttpGet("offer/get/{offerId}")]
    public async Task<IActionResult> GetOfferInfo(int offerId)
    {
        try
        {
            var response = await _mediator.Send(new GetOfferInfoRequest { OfferId = offerId });
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
    }
    
[AllowAnonymous]
[HttpGet("driver/getallbycompanyid/{companyId}")]
public async Task<IActionResult> GetDriversByCompanyId(int companyId)
{
    try
    {
        var response = await _mediator.Send(new GetAllDriversOfCompanyRequest{CompanyId = companyId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}

[AllowAnonymous]
[HttpGet("company/getinfobycompanyid/{companyId}")]
public async Task<IActionResult> GetInfoByCompanyId(int companyId)
{
    try
    {
        var response = await _mediator.Send(new GetInfoOfCompanyRequest{CompanyId = companyId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}


[HttpPost("message/create")]
public async Task<IActionResult> CreateVehicle([FromBody] CreateMessageRequest request)
{
    var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
    if (userIdClaim is null) return Unauthorized();
    if (!int.TryParse(userIdClaim, out var userId)) return BadRequest();
    
    var userRoleClaim =  User.FindFirst(ClaimTypes.Role)?.Value;

    if (userRoleClaim == UserRole.Company.ToString())
    {
        request.CompanyId = userId;
    }
    else if (userRoleClaim == UserRole.Customer.ToString())
    {
        request.CustomerId = userId;
    }
        
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
[HttpGet("vehicle/getallbycompanyid/{companyId}")]
public async Task<IActionResult> GetVehiclesByCompanyId(int companyId)
{
    try
    {
        var response = await _mediator.Send(new GetAllVehiclesOfCompanyRequest{CompanyId = companyId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}

[AllowAnonymous]
[HttpGet("vehicle/get/{vehicleId}")]
public async Task<IActionResult> GetVehicleInfo(int vehicleId)
{
    try
    {
        var response = await _mediator.Send(new GetVehicleInfoRequest{VehicleId = vehicleId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}
[AllowAnonymous]
[HttpGet("message/getall/{offerId}")]
public async Task<IActionResult> GetAllMessages(int offerId)
{
    try
    {
        var response = await _mediator.Send(new GetAllMessagesRequest{OfferId = offerId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}

[AllowAnonymous]
[HttpGet("message/get/{messageId}")]
public async Task<IActionResult> GetMessage(int messageId)
{
    try
    {
        var response = await _mediator.Send(new GetMessageInfoRequest{MessageId = messageId});
        return Ok(response);
    }
    catch
    {
        return BadRequest();
    }
}

}