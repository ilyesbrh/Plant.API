using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant.API.Migrations
{
    public partial class InfosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true),
                    ReadyToUse = table.Column<string>(nullable: true),
                    HowMuchDone = table.Column<int>(nullable: false),
                    UsersNumber = table.Column<int>(nullable: false),
                    AdminsNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");
        }
    }
}
