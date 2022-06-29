namespace ZTM.CORE.DTO.Services;

public interface IDriverService
{
    Task<IEnumerable<DriverBasicInformationResponseDto>> GetAllDriversBasicInfoAsync();
    Task AddNewDriverAsync(DriverBasicInformationResponseDto dto);
    Task UpdateDriver(int id, DriverBasicInformationResponseDto dto);
    Task DeleteDriver(int id);
}