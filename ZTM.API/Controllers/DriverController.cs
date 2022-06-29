using Microsoft.AspNetCore.Mvc;
using ZTM.CORE.DTO;
using ZTM.CORE.DTO.Services;
using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Exceptions;
using ZTM.Infrastructure.Repository;

namespace ZTM.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;
    private readonly IDriverRepository _driverRepository;

    public DriverController(IDriverService driverService, IDriverRepository driverRepository)
    {
        _driverService = driverService;
        _driverRepository = driverRepository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllDrivers()
    {
        return Ok(await _driverService.GetAllDriversBasicInfoAsync());
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewDriver([FromBody] DriverBasicInformationResponseDto dto)
    {
        try
        {
            await _driverService.AddNewDriverAsync(dto);

        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return NoContent();

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver([FromRoute] int id, [FromBody] DriverBasicInformationResponseDto dto)
    {
        await _driverService.UpdateDriver(id, dto);

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] int id)
    {
        await _driverService.DeleteDriver(id);
        return Ok();
    }
}