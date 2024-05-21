using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeatsDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
