using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAuslink.Migrations
{
    public partial class addtdli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialInstruction",
                table: "SeaContainer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HandlerName",
                table: "SeaContainer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientCompanyName",
                table: "SeaContainer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DailyToDoList",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    today = table.Column<DateTime>(nullable: false),
                    MorningJob = table.Column<string>(nullable: true),
                    AfternoonJob = table.Column<string>(nullable: true),
                    ExtraWork = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyToDoList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IssueBoard",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(nullable: false),
                    WhoRaisedThisIssue = table.Column<string>(nullable: false),
                    issueDescription = table.Column<string>(nullable: false),
                    IfIssueIsSolved = table.Column<bool>(nullable: false),
                    WhoSolvedIssue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBoard", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyToDoList");

            migrationBuilder.DropTable(
                name: "IssueBoard");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialInstruction",
                table: "SeaContainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HandlerName",
                table: "SeaContainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClientCompanyName",
                table: "SeaContainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
