using MartianRobots.Application.DTOs.Common;

namespace MartianRobots.Application.DTOs.Responses
{
    public class LostRobotsByMarsIdResponseDTO
    {
        public int Id { get; set; }

        public CoordinateDTO CurrentPosition { get; set; }

        public string Orientation { get; set; }

        public string Instructions { get; set; }
    }
}
