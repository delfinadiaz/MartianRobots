using MartianRobots.Api;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.UnitTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MartianRobots.IntegrationTests.Commands
{
    public class FinalRobotsPositionsIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;


        public FinalRobotsPositionsIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetFinalRobotsPositions_SuccesfulTest()
        {
            var expectedResult = FinalRobotsPositionsTestsHelper.GetSuccesfulResponse();
            var client = _factory.CreateClient();
            var postRequest = new StringContent(JsonConvert.SerializeObject(FinalRobotsPositionsTestsHelper.GetRequest()),Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/mars", postRequest);

            var contentResult = await response.Content.ReadAsStringAsync();
            var finalRobotsPositions = JsonConvert.DeserializeObject<MarsFinalRobotsPositionResponseDTO>(contentResult);

            response.EnsureSuccessStatusCode();
            finalRobotsPositions.MartianRobots.Count().ShouldBe(3);
            finalRobotsPositions.MartianRobots.FirstOrDefault().FinalPosition.ShouldBeEquivalentTo(expectedResult.MartianRobots.FirstOrDefault().FinalPosition);
            Assert.Equal(expectedResult.MartianRobots.FirstOrDefault().IsLost, finalRobotsPositions.MartianRobots.FirstOrDefault().IsLost);
        }

        [Fact]
        public async void GetFinalRobotsPositions_SuccesfulTest_RobotDoesntDropAtSamePoint()
        {
            var expectedResult = FinalRobotsPositionsTestsHelper.GetRobotDoesntDropAtSamePointResponse();
            var client = _factory.CreateClient();
            var postRequest = new StringContent(JsonConvert.SerializeObject(FinalRobotsPositionsTestsHelper.GetRobotDoesntDropAtSamePointRequest()), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/mars", postRequest);

            var contentResult = await response.Content.ReadAsStringAsync();
            var finalRobotsPositions = JsonConvert.DeserializeObject<MarsFinalRobotsPositionResponseDTO>(contentResult);

            response.EnsureSuccessStatusCode();
            finalRobotsPositions.MartianRobots.Count().ShouldBe(2);
            Assert.Equal(expectedResult.MartianRobots.FirstOrDefault().IsLost, finalRobotsPositions.MartianRobots.FirstOrDefault().IsLost);
            Assert.Equal(expectedResult.MartianRobots.LastOrDefault().IsLost, finalRobotsPositions.MartianRobots.LastOrDefault().IsLost);

        }

        [Fact]
        public async void GetFinalRobotsPositions_InvalidRequest()
        {
            var client = _factory.CreateClient();
            var postRequest = new StringContent(JsonConvert.SerializeObject(FinalRobotsPositionsTestsHelper.GetInvalidRequest()), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/mars", postRequest);

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
