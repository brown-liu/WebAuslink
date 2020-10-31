using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientRateSheetID",
                table: "Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientRateSheetID",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
