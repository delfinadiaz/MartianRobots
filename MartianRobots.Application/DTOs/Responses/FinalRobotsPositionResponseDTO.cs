using MartianRobots.Application.DTOs.Common;

namespace MartianRobots.Application.DTOs.Responses
{
    public class FinalRobotsPositionResponseDTO
    {
        public int Id { get; set; }

        public CoordinateDTO FinalPosition { get; set; }

        public char FinalOrientation { get; set; }

        public string IsLost { get; set; }
    }
}
