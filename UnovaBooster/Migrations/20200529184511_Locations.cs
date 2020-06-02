using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace UnovaBooster.Migrations
{
    public partial class Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMove_Moves_MoveID",
                table: "PokemonMove");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMove_Pokemons_PokemonID",
                table: "PokemonMove");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMove_PokemonMoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonMove",
                table: "PokemonMove");

            migrationBuilder.RenameTable(
                name: "PokemonMove",
                newName: "PokemonMoves");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonMove_PokemonID",
                table: "PokemonMoves",
                newName: "IX_PokemonMoves_PokemonID");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonMove_MoveID",
                table: "PokemonMoves",
                newName: "IX_PokemonMoves_MoveID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonMoves",
                table: "PokemonMoves",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMoves_Moves_MoveID",
                table: "PokemonMoves",
                column: "MoveID",
                principalTable: "Moves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMoves_Pokemons_PokemonID",
                table: "PokemonMoves",
                column: "PokemonID",
                principalTable: "Pokemons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMoves_PokemonMoveID",
                table: "PokemonMovesByLevel",
                column: "PokemonMoveID",
                principalTable: "PokemonMoves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMoves_Moves_MoveID",
                table: "PokemonMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMoves_Pokemons_PokemonID",
                table: "PokemonMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMoves_PokemonMoveID",
                table: "PokemonMovesByLevel");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonMoves",
                table: "PokemonMoves");

            migrationBuilder.RenameTable(
                name: "PokemonMoves",
                newName: "PokemonMove");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonMoves_PokemonID",
                table: "PokemonMove",
                newName: "IX_PokemonMove_PokemonID");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonMoves_MoveID",
                table: "PokemonMove",
                newName: "IX_PokemonMove_MoveID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonMove",
                table: "PokemonMove",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMove_Moves_MoveID",
                table: "PokemonMove",
                column: "MoveID",
                principalTable: "Moves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMove_Pokemons_PokemonID",
                table: "PokemonMove",
                column: "PokemonID",
                principalTable: "Pokemons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonMovesByLevel_PokemonMove_PokemonMoveID",
                table: "PokemonMovesByLevel",
                column: "PokemonMoveID",
                principalTable: "PokemonMove",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
