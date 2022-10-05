using System.Collections.Generic;

namespace MartianRobots.Application.DTOs.Responses
{
    public class MarsFinalRobotsPositionResponseDTO
    {
        public int Id { get; set; }

        public IEnumerable<FinalRobotsPositionResponseDTO> MartianRobots { get; set; }

    }
}
