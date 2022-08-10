using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YulinTestOrg.Migrations
{
    public partial class RcgBetRecord2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RcgBetRecords_AspNetUsers_ApplicationUserId",
                table: "RcgBetRecords");

            migrationBuilder.DropIndex(
                name: "IX_RcgBetRecords_ApplicationUserId",
                table: "RcgBetRecords");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RcgBetRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RcgBetRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RcgBetRecords_ApplicationUserId",
                table: "RcgBetRecords",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RcgBetRecords_AspNetUsers_ApplicationUserId",
                table: "RcgBetRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
