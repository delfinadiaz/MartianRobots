using MartianRobots.Application.DTOs.Responses;
using MediatR;
using System.Collections.Generic;

namespace MartianRobots.Application.Queries.RobotQueries.ExploredSurfacesByRobotId
{
    public class ExploredSurfacesByRobotIdRequest : IRequest<IEnumerable<ExploredSurfacesByRobotIdResponseDTO>>
    {
        public int RobotId { get; set; }
    }
}
