using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramPizzaria.Migrations
{
    public partial class Agorava1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bebidas",
                columns: table => new
                {
                    BebidaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeBebida = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bebidas", x => x.BebidaId);
                });

            migrationBuilder.CreateTable(
                name: "pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePizza = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "combos",
                columns: table => new
                {
                    ComboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCombo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    PizzaId = table.Column<int>(nullable: true),
                    BebidaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combos", x => x.ComboId);
                    table.ForeignKey(
                        name: "FK_combos_bebidas_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "bebidas",
                        principalColumn: "BebidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_combos_pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "listIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    item = table.Column<string>(nullable: true),
                    PizzaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listIngredientes_pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_combos_BebidaId",
                table: "combos",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_combos_PizzaId",
                table: "combos",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_listIngredientes_PizzaId",
                table: "listIngredientes",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "combos");

            migrationBuilder.DropTable(
                name: "listIngredientes");

            migrationBuilder.DropTable(
                name: "bebidas");

            migrationBuilder.DropTable(
                name: "pizzas");
        }
    }
}
