using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class UserCandidateRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfbirth",
                table: "Candidates",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_AppUserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Candidates",
                newName: "DateOfbirth");
        }
    }
}
