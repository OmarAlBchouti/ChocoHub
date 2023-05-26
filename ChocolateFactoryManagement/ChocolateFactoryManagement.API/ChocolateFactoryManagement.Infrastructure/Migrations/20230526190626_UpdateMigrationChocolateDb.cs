using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChocolateFactoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrationChocolateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "ChocolateBars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "ChocolateBars");
        }
    }
}
