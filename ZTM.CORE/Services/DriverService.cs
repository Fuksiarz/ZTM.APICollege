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
            Surname = dto.Surname,
            
            
        });

    }

    public async Task UpdateDriver(int id,DriverBasicInformationResponseDto dto)
    {
        var wantedDriver = await _driverRepository.GetById(id);
        
        await _driverRepository.Update(wantedDriver.Id,new Driver()
        {
            FirstName = dto.FirstName,
            Surname = dto.Surname
        });
        
    }

    public async Task DeleteDriver(int id)
    {
        var book = new Driver() {Id = id};
            await _driverRepository.DeleteById(id);
            
    }
}