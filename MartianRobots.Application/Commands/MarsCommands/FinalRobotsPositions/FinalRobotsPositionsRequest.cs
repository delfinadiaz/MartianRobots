using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Responses;
using MediatR;

namespace MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions
{
    public class FinalRobotsPositionsRequest : IRequest<MarsFinalRobotsPositionResponseDTO>
    {
        public MarsDTO Mars { get; set; }

    }
}
