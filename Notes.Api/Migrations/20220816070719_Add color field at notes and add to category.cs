using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.Api.Migrations
{
    public partial class Addcolorfieldatnotesandaddtocategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Notes",
                type: "TEXT",
                nullable: true);
        }
    }
}
