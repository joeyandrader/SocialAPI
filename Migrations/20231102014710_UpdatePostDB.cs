using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagem_Postagem_PostId",
                table: "Postagem");

            migrationBuilder.DropIndex(
                name: "IX_Postagem_PostId",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Postagem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Postagem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_PostId",
                table: "Postagem",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagem_Postagem_PostId",
                table: "Postagem",
                column: "PostId",
                principalTable: "Postagem",
                principalColumn: "Id");
        }
    }
}
