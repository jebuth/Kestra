using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kestra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "BUY" },
                    { 2, false, "SELL" }
                });

            migrationBuilder.InsertData(
                table: "Tickers",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "AAPL" },
                    { 2, false, "GOOG" },
                    { 3, false, "CRM" },
                    { 4, false, "AMZN" },
                    { 5, false, "SNOW" },
                    { 6, false, "NFLX" },
                    { 7, false, "BABA" },
                    { 8, false, "FRT" },
                    { 9, false, "TSLA" },
                    { 10, false, "SQ" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CreatedOnUtc", "Deleted", "OrderId", "Quantity", "TickerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 22, 1, 47, 23, 234, DateTimeKind.Utc).AddTicks(4820), false, 1, 100m, 1 },
                    { 2, new DateTime(2021, 7, 22, 1, 47, 23, 234, DateTimeKind.Utc).AddTicks(4820), false, 1, 50m, 3 },
                    { 4, new DateTime(2021, 7, 22, 1, 47, 23, 234, DateTimeKind.Utc).AddTicks(4820), false, 2, 10m, 4 },
                    { 3, new DateTime(2021, 7, 22, 1, 47, 23, 234, DateTimeKind.Utc).AddTicks(4820), false, 1, 50m, 6 },
                    { 5, new DateTime(2021, 7, 22, 1, 47, 23, 234, DateTimeKind.Utc).AddTicks(4820), false, 1, 1000m, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TickerId",
                table: "Transactions",
                column: "TickerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tickers");
        }
    }
}
