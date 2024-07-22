using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMovieSelectedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MovieSelectedId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MovieSelectedId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MovieSelectedId",
                table: "Tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieSelectedId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieSelectedId",
                table: "Tickets",
                column: "MovieSelectedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MovieSelectedId",
                table: "Tickets",
                column: "MovieSelectedId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
