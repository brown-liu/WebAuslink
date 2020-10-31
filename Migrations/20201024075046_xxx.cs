using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "trId",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wrId",
                table: "Client",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransportRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargePerCBM = table.Column<int>(nullable: false),
                    ChargePerPLT = table.Column<int>(nullable: false),
                    ChargePerFullTruckLoad = table.Column<int>(nullable: false),
                    SpecialCharges1 = table.Column<string>(nullable: true),
                    SpecialCharges2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartageRate20 = table.Column<string>(nullable: true),
                    CartageRateSingle20 = table.Column<string>(nullable: true),
                    CartageRate40 = table.Column<string>(nullable: true),
                    CartageRateSingle40 = table.Column<string>(nullable: true),
                    CartageFAF = table.Column<string>(nullable: true),
                    VGM = table.Column<string>(nullable: true),
                    ATF = table.Column<string>(nullable: true),
                    MPI = table.Column<string>(nullable: true),
                    CartageVBS = table.Column<string>(nullable: true),
                    UnpackM = table.Column<string>(nullable: true),
                    UnpackP = table.Column<string>(nullable: true),
                    OtherCharge1 = table.Column<string>(nullable: true),
                    OtherCharge2 = table.Column<string>(nullable: true),
                    OtherCharge3 = table.Column<string>(nullable: true),
                    OtherCharge4 = table.Column<string>(nullable: true),
                    OtherCharge5 = table.Column<string>(nullable: true),
                    OtherCharge6 = table.Column<string>(nullable: true),
                    OtherCharge7 = table.Column<string>(nullable: true),
                    OtherCharge8 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseRate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_trId",
                table: "Client",
                column: "trId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_wrId",
                table: "Client",
                column: "wrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_TransportRate_trId",
                table: "Client",
                column: "trId",
                principalTable: "TransportRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_WarehouseRate_wrId",
                table: "Client",
                column: "wrId",
                principalTable: "WarehouseRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_TransportRate_trId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_WarehouseRate_wrId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "TransportRate");

            migrationBuilder.DropTable(
                name: "WarehouseRate");

            migrationBuilder.DropIndex(
                name: "IX_Client_trId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_wrId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "trId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "wrId",
                table: "Client");
        }
    }
}
