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
    public async Task GetHeroesAsync_Returns_List_Of_HeroDTO()
    {
        //arrange
        var expectations = new List<HeroDTO>
        {
            new HeroDTO
            {
                id = 1,
                name = "Baron Sengir",
                type = 3,
                story = "Leader of the Sengire Vampire family",
                datecreated = DateTime.Now
            },
            new HeroDTO
            {
                id = 1,
                name = "Batman",
                type = 1,
                story = "Vigilante turn super hero",
                datecreated = DateTime.Now
            }
        };

        var senderMock = new Mock<ISender>();

        senderMock
            .Setup(s => s.Send(It.IsAny<GetHeroQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok<IReadOnlyList<HeroDTO>>(expectations));

        var service = new HeroViewService(senderMock.Object);

        // Act
        var heroes = await service.GetHeroesAsync();

        // Assert
        heroes.Should().BeEquivalentTo(expectations);
        senderMock.Verify(s => s.Send(It.IsAny<GetHeroQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateHeroAsync_Returns_New_Hero()
    {
        //arrange
        var input = new HeroDTO
        {
            name = "Baron Sengir",
            type = 3,
            story = "Leader of the Sengire Vampire family",
            datecreated = DateTime.Now
        };

        var created = new HeroDTO
        {
            id = 1,
            name = "Baron Sengir",
            type = 3,
            story = "Leader of the Sengire Vampire family",
            datecreated = DateTime.Now
        };

        var senderMock = new Mock<ISender>();
        senderMock
            .Setup(s => s.Send(It.IsAny<CreateHeroCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(created));

        var service = new HeroViewService(senderMock.Object);

        // Act
        var result = await service.CreateHeroAsync(input);

        // Assert
        result.story.Should().Be(input.story);
        result.Should().BeEquivalentTo(created);
    }
}
