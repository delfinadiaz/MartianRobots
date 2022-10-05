using AutoMapper;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Application.Commands.MarsCommands.FinalRobotsPositions
{
    public class FinalRobotsPositionsHandler : IRequestHandler<FinalRobotsPositionsRequest, MarsFinalRobotsPositionResponseDTO>
    {
        private readonly IMarsRepository _marsRepository;
        private readonly IMapper _mapper;
        public FinalRobotsPositionsHandler(IMarsRepository marsRepository, IMapper mapper)
        {
            _marsRepository = marsRepository;
            _mapper = mapper;
        }

        public async Task<MarsFinalRobotsPositionResponseDTO> Handle(FinalRobotsPositionsRequest request, CancellationToken cancellationToken)
        {
            var mars = _mapper.Map<Mars>(request.Mars);
            foreach(Robot r in mars.MartianRobots.ToList())
            {
                r.Mars = mars;
                r.ExploredSurfaces.Add(new ExploredSurface
                {
                    Robot = r,
                    Position = r.Orientation.CopyPosition(r.CurrentPosition)
                });
                r.FollowInstructions();
            }
            var marsInserted = _marsRepository.Add(mars);

            return _mapper.Map<MarsFinalRobotsPositionResponseDTO>(marsInserted);
        }
    }
}
