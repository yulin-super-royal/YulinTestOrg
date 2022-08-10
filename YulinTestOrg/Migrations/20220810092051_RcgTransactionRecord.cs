using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YulinTestOrg.Migrations
{
    public partial class RcgTransactionRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RcgTransactionRecords",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "TEXT", nullable: false),
                    SystemCode = table.Column<string>(type: "TEXT", nullable: true),
                    WebId = table.Column<string>(type: "TEXT", nullable: true),
                    MemberAcount = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionTime = table.Column<long>(type: "INTEGER", nullable: false),
                    TransactionType = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RcgTransactionRecords", x => x.TransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RcgTransactionRecords_MemberAcount",
                table: "RcgTransactionRecords",
                column: "MemberAcount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RcgTransactionRecords");
        }
    }
}
