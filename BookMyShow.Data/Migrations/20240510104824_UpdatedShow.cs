using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MaxSeats",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "ShowPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "ShowPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSeats",
                table: "ShowPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "ShowPrices");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "ShowPrices");

            migrationBuilder.DropColumn(
                name: "MaxSeats",
                table: "ShowPrices");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSeats",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
