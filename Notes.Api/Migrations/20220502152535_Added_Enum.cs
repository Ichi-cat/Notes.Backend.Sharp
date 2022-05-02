using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.Api.Migrations
{
    public partial class Added_Enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Matrices_MatrixId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MatrixId",
                table: "Tasks");

            migrationBuilder.AddColumn<byte>(
                name: "MatrixId1",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "Matrices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MatrixId1",
                table: "Tasks",
                column: "MatrixId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Matrices_MatrixId1",
                table: "Tasks",
                column: "MatrixId1",
                principalTable: "Matrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Matrices_MatrixId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MatrixId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MatrixId1",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Matrices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MatrixId",
                table: "Tasks",
                column: "MatrixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Matrices_MatrixId",
                table: "Tasks",
                column: "MatrixId",
                principalTable: "Matrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
