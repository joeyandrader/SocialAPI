using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpAddIdadeUsuarioDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Usuarios");
        }
    }
}
