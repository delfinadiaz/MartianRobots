using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Application.Queries.RobotQueries.ExploredSurfacesByRobotId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Api.Controllers
{
    [ApiController]
    [Route("api/robot")]
    public class RobotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RobotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/exploredsurfaces")]
        [ProducesResponseType(typeof(IEnumerable<ExploredSurfacesByRobotIdResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExploredSurfacesByRobotId(int id)
        {
            var result = await _mediator.Send(new ExploredSurfacesByRobotIdRequest { RobotId = id});

            return Ok(result);
        }
    }
}
