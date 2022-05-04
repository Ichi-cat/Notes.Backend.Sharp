using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.Api.Migrations
{
    public partial class enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Matrices_MatrixId1",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ProgressConditions_ProgressConditionId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MatrixId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProgressConditionId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MatrixId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProgressConditionId1",
                table: "Tasks");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "ProgressConditions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MatrixId",
                table: "Tasks",
                column: "MatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProgressConditionId",
                table: "Tasks",
                column: "ProgressConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Matrices_MatrixId",
                table: "Tasks",
                column: "MatrixId",
                principalTable: "Matrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ProgressConditions_ProgressConditionId",
                table: "Tasks",
                column: "ProgressConditionId",
                principalTable: "ProgressConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Matrices_MatrixId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ProgressConditions_ProgressConditionId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MatrixId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProgressConditionId",
                table: "Tasks");

            migrationBuilder.AddColumn<byte>(
                name: "MatrixId1",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProgressConditionId1",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProgressConditions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MatrixId1",
                table: "Tasks",
                column: "MatrixId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProgressConditionId1",
                table: "Tasks",
                column: "ProgressConditionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Matrices_MatrixId1",
                table: "Tasks",
                column: "MatrixId1",
                principalTable: "Matrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ProgressConditions_ProgressConditionId1",
                table: "Tasks",
                column: "ProgressConditionId1",
                principalTable: "ProgressConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
