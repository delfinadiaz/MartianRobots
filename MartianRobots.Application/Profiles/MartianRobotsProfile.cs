using AutoMapper;
using MartianRobots.Application.DTOs;
using MartianRobots.Application.DTOs.Common;
using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Domain.Common;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Entities.RobotOrientation;
using System;
using System.Reflection;

namespace MartianRobots.Application.Profiles
{
    public class MartianRobotsProfile : Profile
    {
        public MartianRobotsProfile()
        {
            CreateMap<CoordinateDTO, Coordinate>().ReverseMap();
            CreateMap<RobotDTO, Robot>()
                .ForMember(dest => dest.Orientation, opt => opt.MapFrom(s => _getOrientationInstance(s.Orientation[0])));
            CreateMap<MarsDTO, Mars>().ReverseMap();

            CreateMap<Robot, FinalRobotsPositionResponseDTO>()
                .ForMember(dest => dest.FinalOrientation, opt => opt.MapFrom(s => (char)_getOrientationEnum(s.Orientation)))
                .ForMember(dest => dest.IsLost, opt => opt.MapFrom(s => s.IsLost ? "LOST" : ""))
                .ForMember(dest => dest.FinalPosition, opt => opt.MapFrom(s => s.CurrentPosition));

            CreateMap<Mars, MarsFinalRobotsPositionResponseDTO>();

            CreateMap<Robot, LostRobotsByMarsIdResponseDTO>()
                .ForMember(dest => dest.Orientation, opt => opt.MapFrom( s => _getOrientationEnum(s.Orientation)));

            CreateMap<ExploredSurface, ExploredSurfacesByRobotIdResponseDTO>();
        }

        private Orientation _getOrientationInstance(char orientation)
        {
            var className = ((OrientationDTO)orientation).ToString();
            var orientationAssembly = Assembly.GetAssembly(typeof(Orientation));
            var fullyQualifiedName = typeof(Orientation).Namespace + "." + className;
            var orientationType = orientationAssembly.GetType(fullyQualifiedName);
            return (Orientation) Activator.CreateInstance(orientationType);
        }

        private OrientationDTO _getOrientationEnum(Orientation orientation)
        {
            return (OrientationDTO)Enum.Parse(typeof(OrientationDTO), orientation.GetType().Name);
        }
    }
}
