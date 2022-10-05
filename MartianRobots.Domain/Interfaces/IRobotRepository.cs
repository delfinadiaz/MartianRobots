using MartianRobots.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Domain.Interfaces
{
    public interface IRobotRepository : IGenericRepository<Robot>
    {
        Task<IEnumerable<ExploredSurface>> GetExploredSurfacesByRobotId(int id);
    }
}
