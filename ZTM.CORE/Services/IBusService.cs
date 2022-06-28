using ZTM.Infrastructure.Repository;

namespace ZTM.CORE.DTO.Services;

public interface IBusService
{
    Task<IEnumerable<BusBasicInformationResponseDto>> GetAllBusBasicInfosAsync();
    Task AddNewBusAsync(BusBasicInformationResponseDto dto);
}