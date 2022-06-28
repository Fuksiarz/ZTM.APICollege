namespace ZTM.CORE.DTO.Services;

public interface IDriverService
{
    Task<IEnumerable<DriverBasicInformationResponseDto>> GetAllDriversBasicInfoAsync();
    Task AddNewDriverAsync(DriverBasicInformationResponseDto dto);

}