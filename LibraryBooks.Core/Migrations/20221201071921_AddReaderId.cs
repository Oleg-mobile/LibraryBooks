using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBooks.Core.Migrations
{
    public partial class AddReaderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReaderId",
                table: "Books",
                type: "int",
                nullable: true,
                defaultValue: null);
            // INFO:  При добавлении нового стобца в таблицу БД, значение по умолчанию null, чтобы было понятно, какое значение подставить существующим записям.
            // В модели поле nullable. Также отключить каскадное удаление: onDelete: ReferentialAction.NoAction

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReaderId",
                table: "Books",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);  // disabled cascading deletion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReaderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "Books");
        }
    }
}
