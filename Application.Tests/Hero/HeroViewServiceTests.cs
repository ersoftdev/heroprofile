using FluentAssertions;
using Hero.Application.Hero;
using Hero.Application.Hero.CreateHero;
using Hero.Application.Hero.GetHero;
using Hero.Domain.Abstractions;
using Hero.Shared.DTO.Hero;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Hero;

public class HeroViewServiceTests
{
    [Fact]
    public async Task GetHeroesAsync_Returns_Null()
    {
        // Arrange
        var senderMock = new Mock<ISender>();
        var service = new NullHeroViewService(senderMock.Object);

        // Act
        var heroes = await service.GetHeroesAsync();

        // Assert
        Assert.Null(heroes);
    }

    [Fact]
    public async Task CreateHeroAsync_Should_Fail()
    {
        // Arrange
        var senderMock = new Mock<ISender>();
        var service = new NullHeroViewService(senderMock.Object);

        var inputHero = new HeroDTO { name = "Test" };

        //Act
        Result<HeroDTO> result = await service.CreateHeroAsync(inputHero);

        // Assert
        Assert.False(result.Success);                     // it should fail
        Assert.Equal("Create Hero not implemented", result.Error);
    }
}
