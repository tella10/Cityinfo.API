using Microsoft.EntityFrameworkCore.Migrations;

namespace Cityinfo.API.Migrations
{
    public partial class UpdatingPointOfInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointOfInterestDto");

            migrationBuilder.InsertData(
                table: "PointOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The famous place in Abuja", "Gwangalada" },
                    { 2, 1, "The industrious city in Nigeria", "Lagos" },
                    { 3, 2, "Everton Stadium in London UK", "Godison Park" },
                    { 4, 3, "The famous city in US for best technology innovation", "Silicon Valley" },
                    { 5, 3, "The famous city in US for best technology innovation", "Silicon Valley-1" },
                    { 6, 4, "The famous city in US for best technology innovation", "Silicon Valley-1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "PointOfInterestDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterestDto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PointOfInterestDto",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The famous place in Abuja", "Gwangalada" },
                    { 2, "The industrious city in Nigeria", "Lagos" },
                    { 3, "Everton Stadium in London UK", "Godison Park" },
                    { 4, "The famous city in US for best technology innovation", "Silicon Valley" },
                    { 5, "The famous city in US for best technology innovation", "Silicon Valley-1" },
                    { 6, "The famous city in US for best technology innovation", "Silicon Valley-1" }
                });
        }
    }
}
