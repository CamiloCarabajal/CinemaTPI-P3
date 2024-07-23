using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeatCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "SeatCount",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AdminId", "AuthorMovie", "SeatCount", "Title" },
                values: new object[,]
                {
                    { 1, null, "Jonathan Glazer ", 5, "La zona de interés" },
                    { 2, null, "Uruguayo ", 3, "Sociedad de la nieve" }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "MovieId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "MovieId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SeatCount",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AdminId", "AuthorMovie", "Title" },
                values: new object[,]
                {
                    { 3, null, "Jonathan Glazer ", "La zona de interés" },
                    { 4, null, "Uruguayo ", "Sociedad de la nieve" }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "MovieId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "MovieId",
                value: 4);
        }
    }
}
