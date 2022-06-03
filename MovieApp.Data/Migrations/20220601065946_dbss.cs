using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class dbss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingModel",
                columns: table => new
                {
                    bookingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seats = table.Column<int>(type: "int", nullable: false),
                    showTimeModelId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingModel", x => x.bookingid);
                    table.ForeignKey(
                        name: "FK_bookingModel_movieShowTimeModel_showTimeModelId",
                        column: x => x.showTimeModelId,
                        principalTable: "movieShowTimeModel",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_showTimeModelId",
                table: "bookingModel",
                column: "showTimeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingModel");
        }
    }
}
