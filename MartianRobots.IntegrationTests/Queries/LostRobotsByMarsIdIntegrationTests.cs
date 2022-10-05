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

namespace MartianRobots.IntegrationTests.Commands
{
    public class LostRobotsByMarsIdIntegrationTests : BaseIntegrationTest, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public LostRobotsByMarsIdIntegrationTests(WebApplicationFactory<Startup> factory) 
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetLostRobotsByMarsId_SuccesfulTest()
        {
            var marsInserted = CreateMarsWithRobots();
            var lostRobotInserted = marsInserted.MartianRobots.Where(x => x.IsLost).FirstOrDefault();
            
            var response = await _client.GetAsync($"/api/mars/{marsInserted.Id}/lostrobots");

            var contentResult = await response.Content.ReadAsStringAsync();
            var lostRobots = JsonConvert.DeserializeObject<List<LostRobotsByMarsIdResponseDTO>>(contentResult);

            response.EnsureSuccessStatusCode();
            Assert.NotNull(lostRobots);
            lostRobots.Count().ShouldBe(1);
            Assert.Equal(lostRobotInserted.Id, lostRobots.FirstOrDefault().Id);

            DeleteMarsAndItsRobots(marsInserted);
        }

        [Fact]
        public async void GetFinalRobotsPositions_InvalidRequest()
        {
            var nonExistentMarsId = GetNonExistentMarsId();

            var response = await _client.GetAsync($"/api/mars/{nonExistentMarsId}/lostrobots");

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
