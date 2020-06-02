using Microsoft.EntityFrameworkCore.Migrations;

namespace UnovaBooster.Migrations
{
    public partial class MapCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_GymLeaders_GymLeaderID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Regions_RegionID",
                table: "Maps");

            migrationBuilder.AlterColumn<int>(
                name: "RegionID",
                table: "Maps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GymLeaderID",
                table: "Maps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_GymLeaders_GymLeaderID",
                table: "Maps",
                column: "GymLeaderID",
                principalTable: "GymLeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Regions_RegionID",
                table: "Maps",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_GymLeaders_GymLeaderID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Regions_RegionID",
                table: "Maps");

            migrationBuilder.AlterColumn<int>(
                name: "RegionID",
                table: "Maps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GymLeaderID",
                table: "Maps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_GymLeaders_GymLeaderID",
                table: "Maps",
                column: "GymLeaderID",
                principalTable: "GymLeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Regions_RegionID",
                table: "Maps",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
