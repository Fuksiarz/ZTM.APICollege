namespace ZTM.CORE.DTO;

public class DriverBasicInformationResponseDto
{
    public string FirstName { get; set; }
    public string Surname { get; set; }

    public DriverBasicInformationResponseDto(string firstName, string surname)
    {
        FirstName = firstName;
        Surname = surname;
    }
}