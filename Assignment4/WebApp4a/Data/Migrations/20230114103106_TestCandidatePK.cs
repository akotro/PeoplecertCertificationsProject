using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class TestCandidatePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateAppUserId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CandidateAppUserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams",
                column: "CandidateAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CandidateAppUserId",
                table: "Addresses",
                column: "CandidateAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses",
                column: "CandidateAppUserId",
                principalTable: "Candidates",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateAppUserId",
                table: "CandidateExams",
                column: "CandidateAppUserId",
                principalTable: "Candidates",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CandidateAppUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropColumn(
                name: "CandidateAppUserId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "CandidateExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AppUserId",
                table: "Candidates",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
