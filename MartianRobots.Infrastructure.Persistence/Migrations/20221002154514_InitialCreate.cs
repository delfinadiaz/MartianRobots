using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MartianRobots.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarsSize_CoordinateX = table.Column<int>(nullable: false),
                    MarsSize_CoordinateY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrentPosition_CoordinateX = table.Column<int>(nullable: false),
                    CurrentPosition_CoordinateY = table.Column<int>(nullable: false),
                    MarsId = table.Column<int>(nullable: false),
                    Orientation = table.Column<string>(nullable: false),
                    IsLost = table.Column<bool>(nullable: false),
                    Instructions = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Robots_Mars_MarsId",
                        column: x => x.MarsId,
                        principalTable: "Mars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Robots_MarsId",
                table: "Robots",
                column: "MarsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "Mars");
        }
    }
}
