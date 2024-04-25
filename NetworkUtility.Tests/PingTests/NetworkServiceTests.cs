using FluentAssertions;
using FluentAssertions.Extensions;

namespace NetworkUtility.Tests;

public class NetworkServiceTests
{
    private readonly NetworkService _networkService;

    public NetworkServiceTests()
    {
        //SUT
        _networkService = new NetworkService();
    }
    [Fact]
    public void NetworkService_SendPing_ReturnsString()
    {
        // Arrange
        // Act
        var result = _networkService.SendPing();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Ping");
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 3, 5)]
    public void NetworkService_PingTimeout_ReturnsSum(int a, int b, int expected)
    {
        // Arrange
        // Act
        var result = _networkService.PingTimeout(a, b);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void NetworkService_LastPingDate_ReturnsDateTime()
    {
        // Arrange
        // Act
        var result = _networkService.LastPingDate();

        // Assert
        result.Should().BeAfter(1.January(2022));
        result.Should().BeBefore(1.January(2033));
    }

    [Fact]
    public void GetPingOptionsTest()
    {
        // Arrange
        // Act
        var result = _networkService.GetPingOptions();

        // Assert
        result.Should().NotBeNull();
        result.DontFragment.Should().BeTrue();
        result.Ttl.Should().Be(1);
    }


}
