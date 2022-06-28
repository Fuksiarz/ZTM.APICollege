using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Repository;

namespace ZTM.CORE.DTO.Services;

public class BusService:IBusService
{
    private readonly IBusRepository _busRepository;
    
    public BusService(IBusRepository busRepository)
    {
        _busRepository = busRepository;
    }

    public async Task<IEnumerable<BusBasicInformationResponseDto>> GetAllBusBasicInfosAsync()
    {
        var buses = await _busRepository.GetAll();
        
        return buses.Select(x => new BusBasicInformationResponseDto(
            x.Line,
            x.Destination,
            x.Stops
        ));
    }
    public async Task AddNewBusAsync(BusBasicInformationResponseDto dto)
    {
        
        await _busRepository.Add(new Bus()
        {
            Stops = dto.Stops,
            Destination = dto.Destination,
            Line = dto.Line

        });

    }

    // public async Task<IEnumerable<BusBasicInformationResponseDto>> CreateBus()
    // {
    //     
    // }
    
}