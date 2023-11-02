using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBioUsuarioDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idade",
                table: "Usuarios",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Usuarios",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Usuarios",
                newName: "Idade");
        }
    }
}
