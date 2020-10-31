using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class fgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ATF",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageFAF",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageRate20",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageRate40",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageRateSingle20",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageRateSingle40",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartageVBS",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChargePerCBM",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChargePerFullTruckLoad",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChargePerPLT",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MPI",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge1",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge2",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge3",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge4",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge5",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge6",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge7",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCharge8",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialCharges1",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialCharges2",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnpackM",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnpackP",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VGM",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATF",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageFAF",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageRate20",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageRate40",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageRateSingle20",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageRateSingle40",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CartageVBS",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ChargePerCBM",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ChargePerFullTruckLoad",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ChargePerPLT",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "MPI",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge1",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge2",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge3",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge4",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge5",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge6",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge7",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "OtherCharge8",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SpecialCharges1",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SpecialCharges2",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UnpackM",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UnpackP",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "VGM",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "trId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wrId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransportRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargePerCBM = table.Column<int>(type: "int", nullable: false),
                    ChargePerFullTruckLoad = table.Column<int>(type: "int", nullable: false),
                    ChargePerPLT = table.Column<int>(type: "int", nullable: false),
                    SpecialCharges1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialCharges2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageFAF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageRate20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageRate40 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageRateSingle20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageRateSingle40 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartageVBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCharge8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpackM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpackP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VGM = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
