using MartianRobots.Domain.Common;
using MartianRobots.Domain.Entities.RobotOrientation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartianRobots.Domain.Entities
{
    public class Robot
    {
        public Robot()
        {
            ExploredSurfaces = new List<ExploredSurface>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Coordinate CurrentPosition { get; set; }

        [Required]
        public Mars Mars { get; set; }

        [Required]
        public Orientation Orientation { get; set; }

        public bool IsLost { get; set; }

        [Required]
        public string Instructions { get; set; }

        public List<ExploredSurface> ExploredSurfaces { get; set; }

        public void FollowInstructions()
        {
            foreach (char c in Instructions)
            {
                switch (c)
                {
                    case 'R':
                        Orientation.TurnRight(this);
                        break;
                    case 'L':
                        Orientation.TurnLeft(this);
                        break;
                    case 'F':
                        Orientation.MoveForward(this);
                        break;
                }
                if (IsLost)
                    break;
            }
        }
    }
}
