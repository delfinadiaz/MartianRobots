using MartianRobots.Application.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Entities.RobotOrientation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Reflection;

namespace MartianRobots.Infrastructure.Persistence.Contexts
{
    public class MartianRobotsDbContext : DbContext
    {
        public MartianRobotsDbContext(DbContextOptions<MartianRobotsDbContext> options) : base (options)
        {

        }

        public DbSet<Mars> Mars { get; set; }
        public DbSet<Robot> Robots { get; set; }

        public DbSet<ExploredSurface> ExploredSurfaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<Orientation, string>(
                    v => v.GetType().Name,
                    v => _getOrientationInstance(v[0]));

            modelBuilder.Entity<Robot>()
                 .OwnsOne( r => r.CurrentPosition, 
                       cp => {
                           cp.WithOwner();
                           cp.Property(cp => cp.CoordinateX).IsRequired();
                           cp.Property(cp => cp.CoordinateY).IsRequired();
                       })
                 .Property(r => r.Orientation)
                 .HasConversion(converter);

            modelBuilder.Entity<Mars>()
                 .OwnsOne(r => r.MarsSize,
                       ms =>
                       {
                           ms.WithOwner();
                           ms.Property(ms => ms.CoordinateX).IsRequired();
                           ms.Property(ms => ms.CoordinateY).IsRequired();
                       });

            modelBuilder.Entity<ExploredSurface>()
                 .OwnsOne(r => r.Position,
                       cp =>
                       {
                           cp.WithOwner();
                           cp.Property(cp => cp.CoordinateX).IsRequired();
                           cp.Property(cp => cp.CoordinateY).IsRequired();
                       });

           base.OnModelCreating(modelBuilder);
        }

        private Orientation _getOrientationInstance(char orientation)
        {
            var className = ((OrientationDTO)orientation).ToString();
            var orientationAssembly = Assembly.GetAssembly(typeof(Orientation));
            var fullyQualifiedName = typeof(Orientation).Namespace + "." + className;
            var orientationType = orientationAssembly.GetType(fullyQualifiedName);
            return (Orientation)Activator.CreateInstance(orientationType);
        }
    }
}
