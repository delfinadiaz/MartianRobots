using AutoMapper;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MartianRobots.Application.Exceptions;

namespace MartianRobots.Application.Queries.RobotQueries.ExploredSurfacesByRobotId
{
    public class ExploredSurfacesByRobotIdHandler : IRequestHandler<ExploredSurfacesByRobotIdRequest, IEnumerable<ExploredSurfacesByRobotIdResponseDTO>>
    {
        private readonly IRobotRepository _robotRepository;
        private readonly IMapper _mapper;
        public ExploredSurfacesByRobotIdHandler(IRobotRepository robotRepository, IMapper mapper)
        {
            _robotRepository = robotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExploredSurfacesByRobotIdResponseDTO>> Handle(ExploredSurfacesByRobotIdRequest request, CancellationToken cancellationToken)
        {
            if (!_robotRepository.Exists(request.RobotId))
                throw new NotFoundException(nameof(Robot), request.RobotId);

            return _mapper.Map<List<ExploredSurfacesByRobotIdResponseDTO>>(await _robotRepository.GetExploredSurfacesByRobotId(request.RobotId));    
        }
    }
}
