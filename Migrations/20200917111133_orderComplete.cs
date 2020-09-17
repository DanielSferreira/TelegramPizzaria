using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramPizzaria.Migrations
{
    public partial class orderComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ordersCompleted",
                columns: table => new
                {
                    OrdersCompletedId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<double>(nullable: false),
                    ComboNameReference = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DateOrder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersCompleted", x => x.OrdersCompletedId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersCompleted");
        }
    }
}
