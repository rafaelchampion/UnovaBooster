using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace UnovaBooster.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GymLeaders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PlayerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymLeaders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ICS = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BaseHP = table.Column<decimal>(nullable: false),
                    MaxHP = table.Column<decimal>(nullable: false),
                    BaseAttack = table.Column<decimal>(nullable: false),
                    MaxAttack = table.Column<decimal>(nullable: false),
                    BaseDeffense = table.Column<decimal>(nullable: false),
                    MaxDeffense = table.Column<decimal>(nullable: false),
                    BaseSpAttack = table.Column<decimal>(nullable: false),
                    MaxSpAttack = table.Column<decimal>(nullable: false),
                    BaseSpDeffense = table.Column<decimal>(nullable: false),
                    MaxSpDeffense = table.Column<decimal>(nullable: false),
                    BaseSpeed = table.Column<decimal>(nullable: false),
                    MaxSpeed = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTMs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTMs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ItemTypeID = table.Column<int>(nullable: false),
                    StoreOriginalPrice = table.Column<decimal>(nullable: false),
                    StorePromotionalPrice = table.Column<decimal>(nullable: false),
                    PlayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeID",
                        column: x => x.ItemTypeID,
                        principalTable: "ItemTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonElementTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PokemonID = table.Column<int>(nullable: false),
                    ElementTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonElementTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PokemonElementTypes_ElementTypes_ElementTypeID",
                        column: x => x.ElementTypeID,
                        principalTable: "ElementTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonElementTypes_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonSpecimens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PokemonID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    VariationID = table.Column<int>(nullable: false),
                    CurrentHP = table.Column<decimal>(nullable: false),
                    MaxHP = table.Column<decimal>(nullable: false),
                    Fainted = table.Column<bool>(nullable: false),
                    PlayerID = table.Column<int>(nullable: true),
                    PlayerID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonSpecimens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PokemonSpecimens_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PokemonSpecimens_Players_PlayerID1",
                        column: x => x.PlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PokemonSpecimens_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Gym = table.Column<bool>(nullable: false),
                    RegionID = table.Column<int>(nullable: false),
                    GymLeaderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maps_GymLeaders_GymLeaderID",
                        column: x => x.GymLeaderID,
                        principalTable: "GymLeaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ElementTypeID = table.Column<int>(nullable: true),
                    PokemonSpecimenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Moves_ElementTypes_ElementTypeID",
                        column: x => x.ElementTypeID,
                        principalTable: "ElementTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_PokemonSpecimens_PokemonSpecimenID",
                        column: x => x.PokemonSpecimenID,
                        principalTable: "PokemonSpecimens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMovesByLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PokemonID = table.Column<int>(nullable: false),
                    MoveID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMovesByLevel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PokemonMovesByLevel_Moves_MoveID",
                        column: x => x.MoveID,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonMovesByLevel_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    MoveID = table.Column<int>(nullable: false),
                    PokemonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TMs_Moves_MoveID",
                        column: x => x.MoveID,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMs_Pokemons_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                table: "Items",
                column: "ItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerID",
                table: "Items",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_GymLeaderID",
                table: "Maps",
                column: "GymLeaderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maps_RegionID",
                table: "Maps",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ElementTypeID",
                table: "Moves",
                column: "ElementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonSpecimenID",
                table: "Moves",
                column: "PokemonSpecimenID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonElementTypes_ElementTypeID",
                table: "PokemonElementTypes",
                column: "ElementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonElementTypes_PokemonID",
                table: "PokemonElementTypes",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMovesByLevel_MoveID",
                table: "PokemonMovesByLevel",
                column: "MoveID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMovesByLevel_PokemonID",
                table: "PokemonMovesByLevel",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonSpecimens_PlayerID",
                table: "PokemonSpecimens",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonSpecimens_PlayerID1",
                table: "PokemonSpecimens",
                column: "PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonSpecimens_PokemonID",
                table: "PokemonSpecimens",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_TMs_MoveID",
                table: "TMs",
                column: "MoveID");

            migrationBuilder.CreateIndex(
                name: "IX_TMs_PokemonID",
                table: "TMs",
                column: "PokemonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "PokemonElementTypes");

            migrationBuilder.DropTable(
                name: "PokemonMovesByLevel");

            migrationBuilder.DropTable(
                name: "PokemonTMs");

            migrationBuilder.DropTable(
                name: "TMs");

            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "GymLeaders");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "ElementTypes");

            migrationBuilder.DropTable(
                name: "PokemonSpecimens");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
