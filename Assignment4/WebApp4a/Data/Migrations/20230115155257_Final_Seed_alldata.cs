using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class Final_Seed_alldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropColumn(
                name: "CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "CandidateExams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateExamId",
                table: "CandidateExamAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19506327-79f1-403c-8700-f931f4c21b4a", "6e4fc92a-f3d1-4f4c-8ef7-bb5dfd0b70ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a35a1a91-0abf-4ee0-817c-7a8a36b2a538", "bdf417e3-0b67-42d4-b5dd-a6024fcd1ad8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0fbd2f6-a43c-4a49-bdd5-73b03943a49a", "fbd16aeb-b265-4820-8ec4-a2a6bc51841e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44919ce7-b036-43ae-8d38-d1a0eb1c64ad", "790fb538-1444-4cd3-a9da-d3adfab6e4e0" });

            migrationBuilder.InsertData(
                table: "CandidateExams",
                columns: new[] { "Id", "AssessmentCode", "CandidateId", "CandidateScore", "ExamDate", "ExamId", "MaxScore", "PercentScore", "ReportDate", "Result" },
                values: new object[,]
                {
                    { 1, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 16, 15, 39, 31, 800, DateTimeKind.Local).AddTicks(3856), 7, null, null, new DateTime(2022, 9, 17, 2, 20, 46, 984, DateTimeKind.Unspecified).AddTicks(6674), null },
                    { 2, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 12, 25, 1, 19, 33, 730, DateTimeKind.Local).AddTicks(5259), 4, null, null, new DateTime(2022, 12, 24, 11, 21, 56, 51, DateTimeKind.Unspecified).AddTicks(4505), null },
                    { 3, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2022, 6, 20, 15, 42, 11, 39, DateTimeKind.Local).AddTicks(763), 6, null, null, new DateTime(2022, 11, 30, 2, 52, 10, 150, DateTimeKind.Unspecified).AddTicks(5307), null },
                    { 4, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 8, 20, 27, 31, 86, DateTimeKind.Local).AddTicks(1583), 7, null, null, new DateTime(2022, 11, 14, 15, 57, 55, 848, DateTimeKind.Unspecified).AddTicks(8759), null },
                    { 5, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 6, 20, 8, 58, 23, 27, DateTimeKind.Local).AddTicks(521), 4, null, null, new DateTime(2022, 10, 16, 4, 13, 14, 558, DateTimeKind.Unspecified).AddTicks(1260), null },
                    { 6, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 10, 5, 3, 39, 26, 733, DateTimeKind.Local).AddTicks(7789), 3, null, null, new DateTime(2022, 8, 14, 10, 20, 32, 623, DateTimeKind.Unspecified).AddTicks(5797), null },
                    { 7, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 29, 0, 10, 24, 143, DateTimeKind.Local).AddTicks(3883), 3, null, null, new DateTime(2022, 8, 21, 18, 0, 24, 402, DateTimeKind.Unspecified).AddTicks(2325), null },
                    { 8, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 4, 14, 17, 31, 13, 4, DateTimeKind.Local).AddTicks(1709), 3, null, null, new DateTime(2022, 10, 8, 5, 54, 0, 759, DateTimeKind.Unspecified).AddTicks(5543), null },
                    { 9, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 5, 2, 5, 36, 5, 80, DateTimeKind.Local).AddTicks(1390), 2, null, null, new DateTime(2022, 7, 24, 11, 33, 13, 611, DateTimeKind.Unspecified).AddTicks(6051), null },
                    { 10, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2022, 9, 11, 17, 54, 3, 135, DateTimeKind.Local).AddTicks(7509), 7, null, null, new DateTime(2022, 11, 2, 20, 21, 34, 458, DateTimeKind.Unspecified).AddTicks(5362), null }
                });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 5, 12, 54, 13, 289, DateTimeKind.Local).AddTicks(4015), new DateTime(2022, 9, 14, 0, 41, 4, 571, DateTimeKind.Local).AddTicks(6726) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 4, 11, 17, 35, 686, DateTimeKind.Local).AddTicks(9274), new DateTime(2022, 2, 24, 13, 2, 58, 204, DateTimeKind.Local).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 19, 10, 32, 33, 561, DateTimeKind.Local).AddTicks(8756), new DateTime(2018, 1, 8, 23, 24, 39, 986, DateTimeKind.Local).AddTicks(5422) });

            migrationBuilder.InsertData(
                table: "CandidateExamAnswers",
                columns: new[] { "Id", "CandidateExamId", "ChosenOption", "CorrectOption", "IsCorrect" },
                values: new object[,]
                {
                    { 1, 9, "<h2>this is an option</h2>", "<h1>this is an option</h1>", false },
                    { 2, 1, "<h3>this is an option</h3>", "<h2>this is an option</h2>", false },
                    { 3, 3, "<h1>this is an option</h1>", "<h3>this is an option</h3>", false },
                    { 4, 8, "<h1>this is an option</h1>", "<h1>this is an option</h1>", false },
                    { 5, 3, "<h2>this is an option</h2>", "<h1>this is an option</h1>", false },
                    { 6, 8, "<h2>this is an option</h2>", "<h3>this is an option</h3>", false },
                    { 7, 9, "<h3>this is an option</h3>", "<h3>this is an option</h3>", false },
                    { 8, 1, "<h2>this is an option</h2>", "<h3>this is an option</h3>", false },
                    { 9, 10, "<h2>this is an option</h2>", "<h2>this is an option</h2>", false },
                    { 10, 8, "<h1>this is an option</h1>", "<h2>this is an option</h2>", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers",
                column: "CandidateExamId",
                principalTable: "CandidateExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CandidateExamAnswers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateExams");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "CandidateExams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CandidateAppUserId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateExamId",
                table: "CandidateExamAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ce1141d-28cb-4037-8f9e-bf9bd78c134a", "5c1ac1b3-69e5-4015-af97-57a1550b5fcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aaa50580-6a51-4e6e-930b-8a1011c847fd", "a38847fa-f68f-4780-b5ed-a93072d1e7f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "beeae3e7-2792-4e07-b3a4-510e7d9b9692", "423b1b6a-dfc6-4442-b7b0-19eef8efa1f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7b7290a-c966-4411-8827-d916116d1897", "67aa63b0-22e7-4fa1-93d6-3c24f78ec726" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 5, 11, 45, 7, 868, DateTimeKind.Local).AddTicks(7187), new DateTime(2022, 9, 13, 23, 31, 59, 150, DateTimeKind.Local).AddTicks(9901) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 4, 10, 8, 30, 266, DateTimeKind.Local).AddTicks(2362), new DateTime(2022, 2, 24, 11, 53, 52, 783, DateTimeKind.Local).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 19, 9, 23, 28, 141, DateTimeKind.Local).AddTicks(1876), new DateTime(2018, 1, 8, 22, 15, 34, 565, DateTimeKind.Local).AddTicks(8544) });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams",
                column: "CandidateAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers",
                column: "CandidateExamId",
                principalTable: "CandidateExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateAppUserId",
                table: "CandidateExams",
                column: "CandidateAppUserId",
                principalTable: "Candidates",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}
