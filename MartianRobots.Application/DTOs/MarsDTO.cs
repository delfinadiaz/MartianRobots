using MartianRobots.Application.DTOs.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Application.DTOs
{
    public class MarsDTO
    {
        [Required]
        public CoordinateDTO MarsSize { get; set; }

        public IEnumerable<RobotDTO> MartianRobots { get; set; }
    }
}
