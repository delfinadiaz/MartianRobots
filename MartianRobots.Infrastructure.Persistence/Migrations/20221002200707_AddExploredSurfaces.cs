using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MartianRobots.Infrastructure.Persistence.Migrations
{
    public partial class AddExploredSurfaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExploredSurface",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RobotId = table.Column<int>(nullable: false),
                    Position_CoordinateX = table.Column<int>(nullable: true),
                    Position_CoordinateY = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExploredSurface", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExploredSurface_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExploredSurface_RobotId",
                table: "ExploredSurface",
                column: "RobotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExploredSurface");
        }
    }
}
