using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YulinTestOrg.Migrations
{
    public partial class addRcgGameDesk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RcgGameDesks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ServerNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LobbyNo = table.Column<int>(type: "INTEGER", nullable: false),
                    GameNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ServerProperty = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RcgGameDesks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RcgGameDesks");
        }
    }
}
