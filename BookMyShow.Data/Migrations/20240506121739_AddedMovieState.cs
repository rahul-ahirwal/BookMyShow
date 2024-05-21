using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovieState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieState",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bad19dc3-29b2-4baf-a605-8057e7a94133"),
                column: "MovieState",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d4a09cd4-77cc-44ee-a314-36353df7e11f"),
                column: "MovieState",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fd437359-a545-4be5-93b0-fab21b30010f"),
                column: "MovieState",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieState",
                table: "Movies");
        }
    }
}
