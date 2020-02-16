using Microsoft.EntityFrameworkCore.Migrations;

namespace strovollio_api.Migrations
{
    public partial class addTestMigrationToMerchant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestMigration",
                table: "Merchants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestMigration",
                table: "Merchants");
        }
    }
}
