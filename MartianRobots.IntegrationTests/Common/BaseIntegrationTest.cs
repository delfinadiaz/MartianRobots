using MartianRobots.Domain.Common;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Entities.RobotOrientation;
using MartianRobots.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.IntegrationTests.Common
{
    public class BaseIntegrationTest
    {
        private readonly MartianRobotsDbContext _dbContext;

        public BaseIntegrationTest()
        {
            _dbContext = new MartianRobotsDbContextFactory().CreateDbContext(new string[1]);
        }

        public Mars CreateMarsWithRobots()
        {
            var mars = new Mars
            {
                MarsSize = new Coordinate()
                {
                    CoordinateX = 5,
                    CoordinateY = 3
                },
                MartianRobots = new List<Robot>()
                    {
                        new Robot()
                        {
                            CurrentPosition = new Coordinate()
                            {
                                CoordinateX = 1,
                                CoordinateY = 1
                            },
                            Orientation = new East(),
                            Instructions = "RFRFRFRF",
                            IsLost = false
                        },
                        new Robot()
                        {
                            CurrentPosition = new Coordinate()
                            {
                                CoordinateX = 3,
                                CoordinateY = 2
                            },
                            Orientation = new North(),
                            Instructions = "FRRFLLFFRRFLL",
                            IsLost = true
                        }
                }
            };

            mars.MartianRobots.ToList().ForEach(r => r.ExploredSurfaces = new List<ExploredSurface>()
            {
                new ExploredSurface {
                    Robot = r,
                    Position = new Coordinate
                    {
                        CoordinateX = 1,
                        CoordinateY = 1
                    }
                },
                new ExploredSurface {
                    Robot = r,
                    Position = new Coordinate
                    {
                        CoordinateX = 1,
                        CoordinateY = 0
                    }
                }
            });
            _dbContext.Add(mars);
            _dbContext.SaveChanges();

            return mars;
        }

        public void DeleteMarsAndItsRobots(Mars mars)
        {
            _dbContext.Remove(mars);
            _dbContext.SaveChanges();
        }

        public int GetNonExistentMarsId()
        {
            var lastMarsInserted = _dbContext.Mars.OrderByDescending(m => m.Id).FirstOrDefault();
            return lastMarsInserted != null ? lastMarsInserted.Id + 1 : 1;
        }

        public int GetNonExistentRobotId()
        {
            var lastRobotInserted = _dbContext.Robots.OrderByDescending(r => r.Id).FirstOrDefault();
            return lastRobotInserted != null ? lastRobotInserted.Id + 10 : 1;
        }

    }
}
