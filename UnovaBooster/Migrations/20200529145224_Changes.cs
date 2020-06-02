using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace UnovaBooster.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_Moves_MoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_Pokemons_PokemonID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropIndex(
                name: "IX_PokemonMovesByLevel_MoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropColumn(
                name: "MoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonID",
                table: "PokemonMovesByLevel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PokemonMoveID",
                table: "PokemonMovesByLevel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PokemonMove",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PokemonID = table.Column<int>(nullable: false),
                    MoveID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMove", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PokemonMove_Moves_MoveID",
                        column: x => x.MoveID,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonMove_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMovesByLevel_PokemonMoveID",
                table: "PokemonMovesByLevel",
                column: "PokemonMoveID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMove_MoveID",
                table: "PokemonMove",
                column: "MoveID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMove_PokemonID",
                table: "PokemonMove",
                column: "PokemonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_Pokemons_PokemonID",
                table: "PokemonMovesByLevel",
                column: "PokemonID",
                principalTable: "Pokemons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMove_PokemonMoveID",
                table: "PokemonMovesByLevel",
                column: "PokemonMoveID",
                principalTable: "PokemonMove",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_Pokemons_PokemonID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMove_PokemonMoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropTable(
                name: "PokemonMove");

            migrationBuilder.DropIndex(
                name: "IX_PokemonMovesByLevel_PokemonMoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropColumn(
                name: "PokemonMoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonID",
                table: "PokemonMovesByLevel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoveID",
                table: "PokemonMovesByLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMovesByLevel_MoveID",
                table: "PokemonMovesByLevel",
                column: "MoveID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_Moves_MoveID",
                table: "PokemonMovesByLevel",
                column: "MoveID",
                principalTable: "Moves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_Pokemons_PokemonID",
                table: "PokemonMovesByLevel",
                column: "PokemonID",
                principalTable: "Pokemons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
