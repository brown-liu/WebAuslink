using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class addaccountonholdoption2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IfAccountIsOnHold",
                table: "Client",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IfAccountIsOnHold",
                table: "Client");
        }
    }
}
