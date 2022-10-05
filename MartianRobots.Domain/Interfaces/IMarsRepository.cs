using MartianRobots.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Domain.Interfaces
{
    public interface IMarsRepository : IGenericRepository<Mars>
    {
        Task<IEnumerable<Robot>> GetLostRobotsByMarsId(int id);
    }
}
