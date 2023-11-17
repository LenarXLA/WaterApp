using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterApp.Migrations
{
    /// <inheritdoc />
    public partial class migration02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_History",
                table: "History");

            migrationBuilder.RenameTable(
                name: "History",
                newName: "Historys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Historys",
                table: "Historys",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Historys",
                table: "Historys");

            migrationBuilder.RenameTable(
                name: "Historys",
                newName: "History");

            migrationBuilder.AddPrimaryKey(
                name: "PK_History",
                table: "History",
                column: "Id");
        }
    }
}
