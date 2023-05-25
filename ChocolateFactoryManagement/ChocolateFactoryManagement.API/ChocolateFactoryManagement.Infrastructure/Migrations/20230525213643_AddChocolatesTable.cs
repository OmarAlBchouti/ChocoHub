using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChocolateFactoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChocolatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChocolateBars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChocolateBars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChocolateBars_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholesalerStocks",
                columns: table => new
                {
                    ChocolateBarId = table.Column<int>(type: "int", nullable: false),
                    WholesalerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesalerStocks", x => new { x.WholesalerId, x.ChocolateBarId });
                    table.ForeignKey(
                        name: "FK_WholesalerStocks_ChocolateBars_ChocolateBarId",
                        column: x => x.ChocolateBarId,
                        principalTable: "ChocolateBars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WholesalerStocks_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChocolateBars_FactoryId",
                table: "ChocolateBars",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalerStocks_ChocolateBarId",
                table: "WholesalerStocks",
                column: "ChocolateBarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WholesalerStocks");

            migrationBuilder.DropTable(
                name: "ChocolateBars");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropTable(
                name: "Factories");
        }
    }
}
