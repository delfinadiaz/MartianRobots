using MartianRobots.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartianRobots.Domain.Entities
{
    public class ExploredSurface
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RobotId { get; set; }

        public Robot Robot { get; set; }

        public Coordinate Position { get; set; }
    }
}
