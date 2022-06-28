using Microsoft.AspNetCore.Mvc;
using ZTM.CORE.DTO;
using ZTM.CORE.DTO.Services;
using ZTM.Infrastructure.Exceptions;

namespace ZTM.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DriverController:ControllerBase
{
    private readonly IDriverService _driver;

    public DriverController(IDriverService driver)
    {
        _driver = driver;
    }
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAllDrivers()
    {
        return Ok(await _driver.GetAllDriversBasicInfoAsync());
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewBus([FromBody] DriverBasicInformationResponseDto dto)
    {
        try
        {
            await _driver.AddNewDriverAsync(dto);

        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return NoContent();

    }

}