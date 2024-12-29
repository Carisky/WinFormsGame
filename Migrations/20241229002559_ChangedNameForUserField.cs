using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsGame.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameForUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsernameName",
                table: "Users",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UsernameName");
        }
    }
}
