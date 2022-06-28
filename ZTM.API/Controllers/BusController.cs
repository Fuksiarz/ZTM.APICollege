using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZTM.CORE.DTO;
using ZTM.CORE.DTO.Services;
using ZTM.Infrastructure.Exceptions;
using ZTM.Infrastructure.Repository;

namespace ZTM.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BusController:ControllerBase
{
    
    
    private readonly IBusService _busService;

    public BusController( IBusService busService)
    {
        
        _busService = busService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllBuses()
    {

        return Ok(await _busService.GetAllBusBasicInfosAsync());
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewBus([FromBody] BusBasicInformationResponseDto dto)
    {
        try
        {
            await _busService.AddNewBusAsync(dto);

        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return NoContent();

    }
    
    // public async Task<IActionResult>CreateNewBus([FromBody])
    
}