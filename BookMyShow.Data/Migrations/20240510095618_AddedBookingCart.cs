using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingCart",
                columns: table => new
                {
                    BookingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheatreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCart", x => x.BookingCartId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCart");
        }
    }
}
