using Microsoft.EntityFrameworkCore.Migrations;

namespace Cityinfo.API.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_City_CityId",
                table: "PointOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Nigeria", "The capital of Nigeria", "Abuja" },
                    { 2, "Ghana", "The capital of Ghana", "Accra" },
                    { 3, "United Kingdom", "The capital of United Kingdom", "London" }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The famous place in Abuja", "Gwangalada" },
                    { 2, 1, "The industrious city in Nigeria", "Lagos" },
                    { 3, 2, "Everton Stadium in London UK", "Godison Park" },
                    { 4, 3, "The famous city in US for best technology innovation", "Silicon Valley" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
