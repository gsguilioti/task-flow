using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixUserCollaborator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborators_AspNetUsers_UserId1",
                table: "Collaborators");

            migrationBuilder.DropIndex(
                name: "IX_Collaborators_UserId1",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Collaborators",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_UserId",
                table: "Collaborators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborators_AspNetUsers_UserId",
                table: "Collaborators",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborators_AspNetUsers_UserId",
                table: "Collaborators");

            migrationBuilder.DropIndex(
                name: "IX_Collaborators_UserId",
                table: "Collaborators");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Collaborators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Collaborators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_UserId1",
                table: "Collaborators",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborators_AspNetUsers_UserId1",
                table: "Collaborators",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
