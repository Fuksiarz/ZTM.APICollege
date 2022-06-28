using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Repository;

namespace ZTM.CORE.DTO.Services;

public class DriverService:IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<IEnumerable<DriverBasicInformationResponseDto>> GetAllDriversBasicInfoAsync()
    {
        var drivers = await _driverRepository.GetAll();
        return drivers.Select(x => new DriverBasicInformationResponseDto(

            
            x.FirstName,
            x.Surname
        ));
    }

    public async Task AddNewDriverAsync(DriverBasicInformationResponseDto dto)
    {
        await _driverRepository.Add(new Driver()
        {
            FirstName = dto.FirstName,
            Surname = dto.Surname
        });

    }

}