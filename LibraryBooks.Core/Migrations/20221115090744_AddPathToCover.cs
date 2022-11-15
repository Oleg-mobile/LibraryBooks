using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBooks.Core.Migrations
{
    public partial class AddPathToCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToCover",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToCover",
                table: "Books");
        }
    }
}
