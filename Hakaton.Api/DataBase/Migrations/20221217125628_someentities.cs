using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonApi.Database.Migrations
{
    public partial class someentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "TaskName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Tasks",
                newName: "Title");
        }
    }
}
