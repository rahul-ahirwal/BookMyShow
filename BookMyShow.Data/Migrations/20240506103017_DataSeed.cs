using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookMyShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRating", "Cast", "Director", "Duration", "Genre", "Language", "MusicDirector", "Name", "Poster", "Producer", "ReleaseDate", "Trailer" },
                values: new object[,]
                {
                    { new Guid("bad19dc3-29b2-4baf-a605-8057e7a94133"), "13", "Batman", "Robert", 245, "Action, Sci-Fi, Thriller", "English", "Andrew", "Batman Begins", "", "Angella", new DateOnly(2024, 5, 23), "" },
                    { new Guid("d4a09cd4-77cc-44ee-a314-36353df7e11f"), "13", "Batman", "Robert", 231, "Action, Sci-Fi, Thriller", "English", "Andrew", "Batman Returns", "", "Angella, Polo", new DateOnly(2024, 5, 29), "" },
                    { new Guid("fd437359-a545-4be5-93b0-fab21b30010f"), "13", "Batman, Superman", "Robert", 341, "Action, Sci-Fi, Thriller", "English", "Andrew", "Batman vs Superman", "", "Angella, Polo, Colon", new DateOnly(2024, 7, 12), "" }
                });

            migrationBuilder.InsertData(
                table: "Theatres",
                columns: new[] { "Id", "Address", "City", "Name", "PinCode", "State" },
                values: new object[,]
                {
                    { new Guid("13dc6fc9-fb97-4fd6-b700-66f697148447"), "Phoenix Citadel", "Indore", "Citadel Cinemas", "244002", "MP" },
                    { new Guid("612f7744-7535-4ee1-905a-92b8901aee3d"), "Ujjain road", "Dewas", "Abhinav Cinemas", "455001", "MP" },
                    { new Guid("f16b85a3-8e01-4d23-8335-db615c7beec6"), "Ujjain road", "Dewas", "Sanghavi Cinemas", "455001", "MP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bad19dc3-29b2-4baf-a605-8057e7a94133"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d4a09cd4-77cc-44ee-a314-36353df7e11f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fd437359-a545-4be5-93b0-fab21b30010f"));

            migrationBuilder.DeleteData(
                table: "Theatres",
                keyColumn: "Id",
                keyValue: new Guid("13dc6fc9-fb97-4fd6-b700-66f697148447"));

            migrationBuilder.DeleteData(
                table: "Theatres",
                keyColumn: "Id",
                keyValue: new Guid("612f7744-7535-4ee1-905a-92b8901aee3d"));

            migrationBuilder.DeleteData(
                table: "Theatres",
                keyColumn: "Id",
                keyValue: new Guid("f16b85a3-8e01-4d23-8335-db615c7beec6"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
