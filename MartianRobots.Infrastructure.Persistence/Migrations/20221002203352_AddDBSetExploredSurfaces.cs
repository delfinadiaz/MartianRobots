using Microsoft.EntityFrameworkCore.Migrations;

namespace MartianRobots.Infrastructure.Persistence.Migrations
{
    public partial class AddDBSetExploredSurfaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExploredSurface_Robots_RobotId",
                table: "ExploredSurface");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExploredSurface",
                table: "ExploredSurface");

            migrationBuilder.RenameTable(
                name: "ExploredSurface",
                newName: "ExploredSurfaces");

            migrationBuilder.RenameIndex(
                name: "IX_ExploredSurface_RobotId",
                table: "ExploredSurfaces",
                newName: "IX_ExploredSurfaces_RobotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExploredSurfaces",
                table: "ExploredSurfaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExploredSurfaces_Robots_RobotId",
                table: "ExploredSurfaces",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExploredSurfaces_Robots_RobotId",
                table: "ExploredSurfaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExploredSurfaces",
                table: "ExploredSurfaces");

            migrationBuilder.RenameTable(
                name: "ExploredSurfaces",
                newName: "ExploredSurface");

            migrationBuilder.RenameIndex(
                name: "IX_ExploredSurfaces_RobotId",
                table: "ExploredSurface",
                newName: "IX_ExploredSurface_RobotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExploredSurface",
                table: "ExploredSurface",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExploredSurface_Robots_RobotId",
                table: "ExploredSurface",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
