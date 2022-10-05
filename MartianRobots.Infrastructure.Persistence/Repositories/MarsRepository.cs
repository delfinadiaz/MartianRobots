using MartianRobots.Application.DTOs.Responses;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.Infrastructure.Persistence.Repositories
{
    public class MarsRepository : GenericRepository<Mars>, IMarsRepository
    {
        private readonly MartianRobotsDbContext _dbContext;

        public MarsRepository(MartianRobotsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Robot>> GetLostRobotsByMarsId(int id)
        {
            return await _dbContext.Robots.Where(r => r.Mars.Id == id && r.IsLost).ToListAsync();
        }

    }
}
