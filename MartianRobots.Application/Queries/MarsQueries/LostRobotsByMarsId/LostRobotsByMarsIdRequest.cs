using MartianRobots.Application.DTOs.Responses;
using MediatR;
using System.Collections.Generic;

namespace MartianRobots.Application.Queries.MarsQueries.AllRobotsByMarsId
{
    public class LostRobotsByMarsIdRequest : IRequest<IEnumerable<LostRobotsByMarsIdResponseDTO>>
    {
        public int MarsId { get; set; }
    }
}
