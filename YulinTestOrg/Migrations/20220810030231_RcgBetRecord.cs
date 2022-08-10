using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YulinTestOrg.Migrations
{
    public partial class RcgBetRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RcgBetRecords",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MemberAccount = table.Column<string>(type: "TEXT", nullable: true),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Desk = table.Column<string>(type: "TEXT", nullable: true),
                    BetArea = table.Column<string>(type: "TEXT", nullable: true),
                    Bet = table.Column<double>(type: "REAL", nullable: false),
                    Available = table.Column<double>(type: "REAL", nullable: false),
                    WinLose = table.Column<double>(type: "REAL", nullable: false),
                    WaterRate = table.Column<double>(type: "REAL", nullable: false),
                    ActiveNo = table.Column<string>(type: "TEXT", nullable: true),
                    RunNo = table.Column<string>(type: "TEXT", nullable: true),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportDT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ip = table.Column<string>(type: "TEXT", nullable: true),
                    Odds = table.Column<double>(type: "REAL", nullable: false),
                    OriginRecordId = table.Column<long>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RcgBetRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_RcgBetRecords_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RcgBetRecords_ApplicationUserId",
                table: "RcgBetRecords",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RcgBetRecords_MemberAccount",
                table: "RcgBetRecords",
                column: "MemberAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RcgBetRecords");
        }
    }
}
