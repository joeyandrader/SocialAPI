using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoPostTitleDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Postagem",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Postagem");
        }
    }
}
