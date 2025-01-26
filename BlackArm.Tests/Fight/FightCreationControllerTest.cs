using AutoMapper;
using BlackArm.API.Controllers;
using BlackArm.API.DTOs.FightsDto;
using BlackArm.Application.Contracts;
using BlackArm.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlackArm.Tests.Fight;

public class FightCreationControllerTest
{
     private readonly Mock<IRepositoryManager> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly FightController _controller;

        public FightCreationControllerTest()
        {
            _mockRepository = new Mock<IRepositoryManager>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = _mockLogger = new Mock<ILoggerManager>();

            // Create a mock mapper instance for mapping FightForCreatingDto to Fight and Fight to FightDto.
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FightForCreatingDto, Domain.Models.Fight>();
                cfg.CreateMap<Domain.Models.Fight, FightDto>();
            });

            var mapper = new Mapper(configurationProvider);
            _mockMapper.Setup(m => m.Map<Domain.Models.Fight>(It.IsAny<FightForCreatingDto>())).Returns((Domain.Models.Fight)null);
            _mockMapper.Setup(m => m.Map<FightDto>(It.IsAny<Domain.Models.Fight>())).Returns((FightDto)null);
            _controller = new FightController(_mockRepository.Object, _mockLogger.Object,_mockMapper.Object);
        }

        [Fact]
        public async Task CreateFightForCompetition_ValidInput_ReturnsOk()
        {
            // Arrange
            var competitionId = Guid.NewGuid();
            var fightForCreatingDto = new FightForCreatingDto
            {
                Wrestler1Id = Guid.Parse("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
                Wrestler2Id = Guid.Parse("7bb4f59c-dadc-4918-a215-730dd34f03d4"),
                WinnerId = Guid.Parse("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
            };

            var competition = new Competition
            {
                CompetitionId = Guid.NewGuid(),
                CompetitionName = "Competition",
                CompetitionDate = DateTime.Now,
            };
            _mockRepository.Setup(repo => repo.Competition.GetCompetitionAsync(competitionId, false)).ReturnsAsync(competition);
            var fightEntity = new Domain.Models.Fight();
            _mockMapper.Setup(m => m.Map<Domain.Models.Fight>(fightForCreatingDto)).Returns(fightEntity);
            _mockMapper.Setup(m => m.Map<FightDto>(fightEntity)).Returns(new FightDto());
            
            _mockRepository.Setup(repo => repo.Fight.CreateFightForCompetition(competitionId, fightEntity)).Verifiable();
            _mockRepository.Setup(repo => repo.SaveAsync());
            // Act
            var result = await _controller.CreateFighForCompetition(competitionId, fightForCreatingDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value); //Check that the returned object is not null
            _mockRepository.VerifyAll();

        }

        [Fact]
        public async Task CreateFightForCompetition_InvalidModelState_ReturnsUnprocessableEntity()
        {
            // Arrange
            var competitionId = Guid.NewGuid();
            var fightForCreatingDto = new FightForCreatingDto
            {
                Wrestler1Id = Guid.Parse("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
                Wrestler2Id = Guid.Parse("7bb4f59c-dadc-4918-a215-730dd34f03d4"),
                WinnerId = Guid.Parse("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
            };
            _controller.ModelState.AddModelError("Error", "Invalid Data");

            // Act
            var result = await _controller.CreateFighForCompetition(competitionId, fightForCreatingDto);

            // Assert
            var unprocessableEntityResult = Assert.IsType<UnprocessableEntityObjectResult>(result);
            Assert.NotNull(unprocessableEntityResult.Value);
            //Assert.Equal(StatusCodes.Status422UnprocessableEntity, result.StatusCode); //Alternative assertion
        }


        // Add more test cases for various scenarios:
        // - Competition not found
        // - Repository errors (e.g., SaveAsync throws exception)
        // - Mapping errors


    }
