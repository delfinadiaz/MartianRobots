﻿// <auto-generated />
using MartianRobots.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MartianRobots.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MartianRobotsDbContext))]
    partial class MartianRobotsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MartianRobots.Domain.Entities.ExploredSurface", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("RobotId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RobotId");

                    b.ToTable("ExploredSurfaces");
                });

            modelBuilder.Entity("MartianRobots.Domain.Entities.Mars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("Mars");
                });

            modelBuilder.Entity("MartianRobots.Domain.Entities.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsLost")
                        .HasColumnType("boolean");

                    b.Property<int>("MarsId")
                        .HasColumnType("integer");

                    b.Property<string>("Orientation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MarsId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("MartianRobots.Domain.Entities.ExploredSurface", b =>
                {
                    b.HasOne("MartianRobots.Domain.Entities.Robot", "Robot")
                        .WithMany("ExploredSurfaces")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MartianRobots.Domain.Common.Coordinate", "Position", b1 =>
                        {
                            b1.Property<int>("ExploredSurfaceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("CoordinateX")
                                .HasColumnType("integer");

                            b1.Property<int>("CoordinateY")
                                .HasColumnType("integer");

                            b1.HasKey("ExploredSurfaceId");

                            b1.ToTable("ExploredSurfaces");

                            b1.WithOwner()
                                .HasForeignKey("ExploredSurfaceId");
                        });
                });

            modelBuilder.Entity("MartianRobots.Domain.Entities.Mars", b =>
                {
                    b.OwnsOne("MartianRobots.Domain.Common.Coordinate", "MarsSize", b1 =>
                        {
                            b1.Property<int>("MarsId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("CoordinateX")
                                .HasColumnType("integer");

                            b1.Property<int>("CoordinateY")
                                .HasColumnType("integer");

                            b1.HasKey("MarsId");

                            b1.ToTable("Mars");

                            b1.WithOwner()
                                .HasForeignKey("MarsId");
                        });
                });

            modelBuilder.Entity("MartianRobots.Domain.Entities.Robot", b =>
                {
                    b.HasOne("MartianRobots.Domain.Entities.Mars", "Mars")
                        .WithMany("MartianRobots")
                        .HasForeignKey("MarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MartianRobots.Domain.Common.Coordinate", "CurrentPosition", b1 =>
                        {
                            b1.Property<int>("RobotId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("CoordinateX")
                                .HasColumnType("integer");

                            b1.Property<int>("CoordinateY")
                                .HasColumnType("integer");

                            b1.HasKey("RobotId");

                            b1.ToTable("Robots");

                            b1.WithOwner()
                                .HasForeignKey("RobotId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
