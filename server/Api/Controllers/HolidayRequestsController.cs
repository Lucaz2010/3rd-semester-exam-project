namespace Api.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

[ApiController]
[Route("api/holiday-requests")]
[Authorize]
public class HolidayRequestsController(
    HolidayRequestService holidayRequestService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateRequest(CreateHolidayRequestDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue("sub");

        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        try
        {
            var result = holidayRequestService.CreateRequest(userId, dto);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpGet("mine")]
    public IActionResult GetMyRequests()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue("sub");

        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var requests = holidayRequestService.GetMyRequests(userId);

        return Ok(requests);
    }
}