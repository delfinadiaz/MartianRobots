using MartianRobots.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartianRobots.Domain.Entities
{
    public class Mars
    {
        public Mars()
        {
            MartianRobots = new List<Robot>();
            Scents = new List<Coordinate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Coordinate MarsSize { get; set; }

        public IEnumerable<Robot> MartianRobots { get; set; }

        [NotMapped]
        public List<Coordinate> Scents { get; set; }
    }
}
