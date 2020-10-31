using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class add2moreforseacontainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationSite",
                table: "SeaContainer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JobFullyCompleted",
                table: "SeaContainer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationSite",
                table: "SeaContainer");

            migrationBuilder.DropColumn(
                name: "JobFullyCompleted",
                table: "SeaContainer");
        }
    }
}
