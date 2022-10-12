using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class EditResttoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurants_restaurantsAddress_RestaurantsAddressId",
                table: "restaurants");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_RestaurantsAddressId",
                table: "restaurants");

            migrationBuilder.RenameColumn(
                name: "RestaurantsAddressId",
                table: "restaurants",
                newName: "HouseNumber");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "restaurantsAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "restaurants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "restaurants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_restaurantsAddress_RestaurantId",
                table: "restaurantsAddress",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurantsAddress_restaurants_RestaurantId",
                table: "restaurantsAddress",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurantsAddress_restaurants_RestaurantId",
                table: "restaurantsAddress");

            migrationBuilder.DropIndex(
                name: "IX_restaurantsAddress_RestaurantId",
                table: "restaurantsAddress");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "restaurantsAddress");

            migrationBuilder.DropColumn(
                name: "City",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "restaurants");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "restaurants",
                newName: "RestaurantsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_RestaurantsAddressId",
                table: "restaurants",
                column: "RestaurantsAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_restaurants_restaurantsAddress_RestaurantsAddressId",
                table: "restaurants",
                column: "RestaurantsAddressId",
                principalTable: "restaurantsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
