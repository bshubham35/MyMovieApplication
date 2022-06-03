using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieApp.Data.Migrations
{
    public partial class mymovieapplication3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "thetreModels",
                columns: table => new
                {
                    ThetreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThetreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThetreLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThetreCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thetreModels", x => x.ThetreId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thetreModels");
        }
    }
}
