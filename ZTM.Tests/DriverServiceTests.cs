using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using ZTM.CORE.DTO.Services;
using ZTM.Infrastructure.Repository;

namespace ZTM.Tests;

public class DriverServiceTests
{
    
    [Fact]
    public async Task ShouldReturnGivenNameAndSurname()
    {
        var driver = new DriverService(Mock.Of<IDriverRepository>());
        var result = await driver.GetAllDriversBasicInfoAsync();
        result.Should().BeEmpty();
    }
}