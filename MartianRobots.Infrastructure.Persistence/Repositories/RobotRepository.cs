using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.Infrastructure.Persistence.Repositories
{
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        private readonly MartianRobotsDbContext _dbContext;

        public RobotRepository(MartianRobotsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExploredSurface>> GetExploredSurfacesByRobotId(int id)
        {
            return await _dbContext.ExploredSurfaces.Where(r => r.Robot.Id == id).ToListAsync();
        }
    }
}
