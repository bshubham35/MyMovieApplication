using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieApp.Data.Migrations
{
    public partial class movieapplication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieModel",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieModel", x => x.MovieId);
                });

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

            migrationBuilder.CreateTable(
                name: "userModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MovieTime",
                columns: table => new
                {
                    MovieTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ThetreId = table.Column<int>(type: "int", nullable: false),
                    ThetreModelThetreId = table.Column<int>(type: "int", nullable: true),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTime", x => x.MovieTimeId);
                    table.ForeignKey(
                        name: "FK_MovieTime_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTime_thetreModels_ThetreModelThetreId",
                        column: x => x.ThetreModelThetreId,
                        principalTable: "thetreModels",
                        principalColumn: "ThetreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieBooking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ThetreId = table.Column<int>(type: "int", nullable: false),
                    MovieShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBooking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_MovieBooking_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieBooking_thetreModels_ThetreId",
                        column: x => x.ThetreId,
                        principalTable: "thetreModels",
                        principalColumn: "ThetreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieBooking_userModel_UserId",
                        column: x => x.UserId,
                        principalTable: "userModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_MovieId",
                table: "MovieBooking",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_ThetreId",
                table: "MovieBooking",
                column: "ThetreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_UserId",
                table: "MovieBooking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTime_MovieId",
                table: "MovieTime",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTime_ThetreModelThetreId",
                table: "MovieTime",
                column: "ThetreModelThetreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieBooking");

            migrationBuilder.DropTable(
                name: "MovieTime");

            migrationBuilder.DropTable(
                name: "userModel");

            migrationBuilder.DropTable(
                name: "movieModel");

            migrationBuilder.DropTable(
                name: "thetreModels");
        }
    }
}
