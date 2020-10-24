using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyName = table.Column<string>(nullable: true),
                    ClientRateSheetID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeaContainer",
                columns: table => new
                {
                    ContainerNumber = table.Column<string>(nullable: false),
                    OceanFreightETA = table.Column<DateTime>(nullable: false),
                    TimeToYard = table.Column<DateTime>(nullable: true),
                    ClientCompanyName = table.Column<string>(nullable: true),
                    HandlerName = table.Column<string>(nullable: true),
                    IfCartageOnly = table.Column<bool>(nullable: false),
                    IfRequireDelivery = table.Column<bool>(nullable: false),
                    IfRequireStorage = table.Column<bool>(nullable: false),
                    IfBookedCartage = table.Column<bool>(nullable: false),
                    Reference = table.Column<bool>(nullable: false),
                    IfEnteredCartonCloud = table.Column<bool>(nullable: false),
                    IfInvoiced = table.Column<bool>(nullable: false),
                    SpecialInstruction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeaContainer", x => x.ContainerNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "SeaContainer");
        }
    }
}
