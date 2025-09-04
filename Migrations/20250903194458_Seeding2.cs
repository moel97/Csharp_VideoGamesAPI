using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 1,
                column: "Publisher",
                value: "Nintendo,Nintendo2,Nintendo3");

            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 2,
                column: "Publisher",
                value: "Sony Interactive Entertainment,Nintendo");

            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 3,
                column: "Publisher",
                value: " Rockstar Games,Sony Interactive Entertainment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 1,
                column: "Publisher",
                value: "[\"Nintendo\",\"Nintendo2\",\"Nintendo3\"]");

            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 2,
                column: "Publisher",
                value: "[\"Sony Interactive Entertainment\",\"Nintendo\",\"\"]");

            migrationBuilder.UpdateData(
                table: "VideoGames",
                keyColumn: "id",
                keyValue: 3,
                column: "Publisher",
                value: "[\" Rockstar Games\",\"Sony Interactive Entertainment\"]");
        }
    }
}
