using AutoMapper;
using MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Application.Profiles;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MartianRobots.UnitTests.Common;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using Xunit;

namespace MartianRobots.UnitTests.Commands
{
    public class FinalRobotsPositionsUnitTests
    {
        private readonly IMapper _mapper;
        private readonly FinalRobotsPositionsHandler _handler;
        private readonly FinalRobotsPositionsRequestValidator _validator;
        private Mock<IMarsRepository> _repository;

        public FinalRobotsPositionsUnitTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MartianRobotsProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _repository = new Mock<IMarsRepository>();

            _handler = new FinalRobotsPositionsHandler(_repository.Object, _mapper);

            _validator = new FinalRobotsPositionsRequestValidator();
        }

        [Fact]
        public async void GetFinalRobotsPositions_SuccesfulTest()
        {
            _repository.Setup(r => r.Add(It.IsAny<Mars>()))
                .Returns(FinalRobotsPositionsTestsHelper.GetMarsResponse());

            var expectedResult = FinalRobotsPositionsTestsHelper.GetSuccesfulResponse();

            var result = await _handler.Handle(FinalRobotsPositionsTestsHelper.GetRequest(), CancellationToken.None);

            result.ShouldBeOfType<MarsFinalRobotsPositionResponseDTO>();
            result.MartianRobots.Count().ShouldBe(3);
            result.ShouldBeEquivalentTo(expectedResult);

        }

        [Fact]
        public async void GetFinalRobotsPositions_SuccesfulTest_RobotDoesntDropAtSamePoint()
        {
            _repository.Setup(r => r.Add(It.IsAny<Mars>()))
                .Returns(FinalRobotsPositionsTestsHelper.GetMarsRobotDoesntDropAtSamePointResponse());

            var expectedResult = FinalRobotsPositionsTestsHelper.GetRobotDoesntDropAtSamePointResponse();

            var result = await _handler.Handle(FinalRobotsPositionsTestsHelper.GetRobotDoesntDropAtSamePointRequest(), CancellationToken.None);

            result.ShouldBeOfType<MarsFinalRobotsPositionResponseDTO>();
            result.MartianRobots.Count().ShouldBe(2);
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Fact]
        public async void GetFinalRobotsPositions_InvalidRequest()
        {
            var result = _validator.Validate(FinalRobotsPositionsTestsHelper.GetInvalidRequest());
            Assert.False(result.IsValid);
            Assert.NotNull(result.Errors);
            Assert.Equal(5, result.Errors.Count);
        }

        [Fact]
        public async void GetFinalRobotsPositions_ValidRequest()
        {
            var result = _validator.Validate(FinalRobotsPositionsTestsHelper.GetRequest());
            Assert.True(result.IsValid);
        }

    }
}
