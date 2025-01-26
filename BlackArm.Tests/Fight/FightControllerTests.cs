using AutoMapper;
using BlackArm.API.Controllers;
using BlackArm.API.DTOs.FightsDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlackArm.Tests.Fight;

public class FightControllerTests
{
    private readonly Mock<IRepositoryManager> _repositoryMock;
    private readonly Mock<ILoggerManager> _mockLogger;
    private readonly IMapper _mapper;
    private readonly FightController _controller;

    public FightControllerTests()
    {
        _repositoryMock = new Mock<IRepositoryManager>();
        _mockLogger = new Mock<ILoggerManager>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Models.Fight, FightDto>();
        });
        _mapper = config.CreateMapper();
        
        _controller = new FightController(_repositoryMock.Object, _mockLogger.Object, _mapper);
    }

    [Fact]
    public async Task GetFightForCompetition_ReturnsNotFound_WhenCompetitionIsNull()
    {
        //Arrange
        var competitionId = Guid.NewGuid();
        var fightId = Guid.NewGuid();
        _repositoryMock.Setup(repo => repo.Competition.GetCompetitionAsync(competitionId, false))
            .ReturnsAsync((Competition)null);
        
        //act
        var result = await _controller.GetFightForCompetition(competitionId, fightId, CancellationToken.None);
        
        //assert
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task GetFightForCompetition_ReturnsNotFound_WhenFightIsNull()
    {
        // Arrange
        var competitionId = Guid.NewGuid();
        var fightId = Guid.NewGuid();
        var competition = new Competition { CompetitionId = competitionId };

        _repositoryMock.Setup(repo => repo.Competition.GetCompetitionAsync(competitionId, false))
            .ReturnsAsync(competition);

        _repositoryMock.Setup(repo => repo.Fight.GetFightAsync(competitionId, fightId, CancellationToken.None, false))
            .ReturnsAsync((Domain.Models.Fight)null);

        // Act
        var result = await _controller.GetFightForCompetition(competitionId, fightId, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task GetFightForCompetition_ReturnsOk_WhenFightIsFound()
    {
        // Arrange
        var competitionId = Guid.NewGuid();
        var fightId = Guid.NewGuid();
        var competition = new Competition { CompetitionId = competitionId };
        var fight = new Domain.Models.Fight { FightId = fightId };

        _repositoryMock.Setup(repo => repo.Competition.GetCompetitionAsync(competitionId, false))
            .ReturnsAsync(competition);

        _repositoryMock.Setup(repo => repo.Fight.GetFightAsync(competitionId, fightId, CancellationToken.None, false))
            .ReturnsAsync(fight);

        // Act
        var result = await _controller.GetFightForCompetition(competitionId, fightId, CancellationToken.None) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FightDto>(result.Value);
        _mockLogger.Verify(logger => logger.LogError(It.IsAny<string>()), Times.Never);
    }
    
  
    
}