using MartianRobots.Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace MartianRobots.Application.DTOs
{
    public class RobotDTO
    {
        [Required]
        public CoordinateDTO CurrentPosition { get; set; }


        [Required]
        public string Orientation { get; set; }


        [Required]
        public string Instructions { get; set; }
    }
}
