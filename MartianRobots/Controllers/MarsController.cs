using MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Application.Queries.MarsQueries.AllRobotsByMarsId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Api.Controllers
{
    [ApiController]
    [Route("api/mars")]
    public class MarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MarsFinalRobotsPositionResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFinalRobotsPositions([FromBody] FinalRobotsPositionsRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{id}/lostrobots")]
        [ProducesResponseType(typeof(IEnumerable<LostRobotsByMarsIdResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLostRobotsByMarsId(int id)
        {
            var result = await _mediator.Send(new LostRobotsByMarsIdRequest { MarsId = id});

            return Ok(result);
        }
    }
}
