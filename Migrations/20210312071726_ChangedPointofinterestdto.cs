using Microsoft.EntityFrameworkCore.Migrations;

namespace Cityinfo.API.Migrations
{
    public partial class ChangedPointofinterestdto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Country", "Description", "Name" },
                values: new object[] { 4, "United State", "The famous state in United State", "New York" });

            migrationBuilder.InsertData(
                table: "PointOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 5, 3, "The famous city in US for best technology innovation", "Silicon Valley-1" });

            migrationBuilder.InsertData(
                table: "PointOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 6, 4, "The famous city in US for best technology innovation", "Silicon Valley-1" });

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterest_City_CityId",
                table: "PointOfInterest",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_City_CityId",
                table: "PointOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest");

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "PointOfInterestDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterestDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfInterestDto_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterestDto_cityId",
                table: "PointOfInterestDto",
                column: "cityId");
        }
    }
}
