using MartianRobots.Api;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.IntegrationTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MartianRobots.IntegrationTests.Queries
{
    public class ExploredSurfacesByRobotIdIntegrationTests : BaseIntegrationTest, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public ExploredSurfacesByRobotIdIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetExploredSurfacesByRobotId_SuccesfulTest()
        {
            var marsInserted = CreateMarsWithRobots();
            var robotId = marsInserted.MartianRobots.FirstOrDefault().Id;

            var response = await _client.GetAsync($"/api/robot/{robotId}/exploredsurfaces");

            var contentResult = await response.Content.ReadAsStringAsync();
            var exploredSurfaces = JsonConvert.DeserializeObject<List<ExploredSurfacesByRobotIdResponseDTO>>(contentResult);

            response.EnsureSuccessStatusCode();
            Assert.NotNull(exploredSurfaces);
            exploredSurfaces.Count().ShouldBe(2);

            DeleteMarsAndItsRobots(marsInserted);
        }

        [Fact]
        public async void GetExploredSurfacesByRobotId_InvalidRequest()
        {
            var nonExistentRobotId = GetNonExistentRobotId();

            var response = await _client.GetAsync($"/api/robot/{nonExistentRobotId}/exploredsurfaces");

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
