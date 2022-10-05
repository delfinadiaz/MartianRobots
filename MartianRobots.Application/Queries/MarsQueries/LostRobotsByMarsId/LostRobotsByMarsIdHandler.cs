using AutoMapper;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Application.Exceptions;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Application.Queries.MarsQueries.AllRobotsByMarsId
{
    public class LostRobotsByMarsIdHandler : IRequestHandler<LostRobotsByMarsIdRequest, IEnumerable<LostRobotsByMarsIdResponseDTO>>
    {
        private readonly IMarsRepository _marsRepository;
        private readonly IMapper _mapper;
        public LostRobotsByMarsIdHandler(IMarsRepository marsRepository, IMapper mapper)
        {
            _marsRepository = marsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LostRobotsByMarsIdResponseDTO>> Handle(LostRobotsByMarsIdRequest request, CancellationToken cancellationToken)
        {
            if (!_marsRepository.Exists(request.MarsId))
                throw new NotFoundException(nameof(Mars), request.MarsId);

            return _mapper.Map<List<LostRobotsByMarsIdResponseDTO>>( await _marsRepository.GetLostRobotsByMarsId(request.MarsId));
        }
    }
}
