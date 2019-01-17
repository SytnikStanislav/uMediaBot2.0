using Microsoft.EntityFrameworkCore.Migrations;

namespace uMediaBotAPI.DAL.Migrations
{
    public partial class AddPreviousFolderIdToFolderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousFolderId",
                table: "Folders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousFolderId",
                table: "Folders");
        }
    }
}
