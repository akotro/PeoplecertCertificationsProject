using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class RenamedQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TopicId",
                table: "Questions",
                newName: "IX_Questions_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_DifficultyLevelId",
                table: "Questions",
                newName: "IX_Questions_DifficultyLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d0314a9b-60d4-4d28-b13a-13ca35c89395", "a25d13f4-db70-4972-a2ad-199caa96549b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9f65cf0-8ef4-4a80-ad9b-778b9120a291", "159ce4ac-9c51-481b-b560-151b1aedde19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be571cb6-5f0e-4e6b-83fb-dfc516272be8", "4aa240c1-2a7a-4799-82e2-b61b6d5d75fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a16ca7f8-ad01-45e4-8065-2e979b0aba40", "2304c06c-93f3-4c72-b6b7-84b1d85c1fb4" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 16, 17, 1, 42, 383, DateTimeKind.Local).AddTicks(1022), new DateTime(2022, 9, 17, 2, 57, 50, 514, DateTimeKind.Unspecified).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 25, 2, 41, 44, 313, DateTimeKind.Local).AddTicks(2393), new DateTime(2022, 12, 24, 12, 35, 46, 911, DateTimeKind.Unspecified).AddTicks(3195) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 20, 17, 4, 21, 621, DateTimeKind.Local).AddTicks(7908), new DateTime(2022, 11, 30, 3, 56, 54, 561, DateTimeKind.Unspecified).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 8, 21, 49, 41, 668, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 11, 14, 16, 56, 53, 499, DateTimeKind.Unspecified).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 20, 10, 20, 33, 609, DateTimeKind.Local).AddTicks(7674), new DateTime(2022, 10, 16, 5, 1, 10, 534, DateTimeKind.Unspecified).AddTicks(3929) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 5, 5, 1, 37, 316, DateTimeKind.Local).AddTicks(5003), new DateTime(2022, 8, 14, 10, 45, 0, 745, DateTimeKind.Unspecified).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 29, 1, 32, 34, 726, DateTimeKind.Local).AddTicks(1105), new DateTime(2022, 8, 21, 18, 27, 36, 753, DateTimeKind.Unspecified).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 14, 18, 53, 23, 586, DateTimeKind.Local).AddTicks(8934), new DateTime(2022, 10, 8, 6, 38, 58, 804, DateTimeKind.Unspecified).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 2, 6, 58, 15, 662, DateTimeKind.Local).AddTicks(8618), new DateTime(2022, 7, 24, 11, 49, 51, 673, DateTimeKind.Unspecified).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 11, 19, 16, 13, 718, DateTimeKind.Local).AddTicks(4741), new DateTime(2022, 11, 2, 21, 16, 6, 964, DateTimeKind.Unspecified).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 5, 14, 16, 23, 871, DateTimeKind.Local).AddTicks(5368), new DateTime(2022, 9, 14, 2, 3, 15, 153, DateTimeKind.Local).AddTicks(8088) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 4, 12, 39, 46, 269, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 2, 24, 14, 25, 8, 786, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 19, 11, 54, 44, 144, DateTimeKind.Local).AddTicks(41), new DateTime(2018, 1, 9, 0, 46, 50, 568, DateTimeKind.Local).AddTicks(6709) });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Difficulty" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "DifficultyLevelId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                column: "DifficultyLevelId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                column: "DifficultyLevelId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                column: "DifficultyLevelId",
                value: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                table: "Questions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TopicId",
                table: "Question",
                newName: "IX_Question_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_DifficultyLevelId",
                table: "Question",
                newName: "IX_Question_DifficultyLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 16, 15, 39, 31, 800, DateTimeKind.Local).AddTicks(3856), new DateTime(2022, 9, 17, 2, 20, 46, 984, DateTimeKind.Unspecified).AddTicks(6674) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 25, 1, 19, 33, 730, DateTimeKind.Local).AddTicks(5259), new DateTime(2022, 12, 24, 11, 21, 56, 51, DateTimeKind.Unspecified).AddTicks(4505) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 20, 15, 42, 11, 39, DateTimeKind.Local).AddTicks(763), new DateTime(2022, 11, 30, 2, 52, 10, 150, DateTimeKind.Unspecified).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 8, 20, 27, 31, 86, DateTimeKind.Local).AddTicks(1583), new DateTime(2022, 11, 14, 15, 57, 55, 848, DateTimeKind.Unspecified).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 20, 8, 58, 23, 27, DateTimeKind.Local).AddTicks(521), new DateTime(2022, 10, 16, 4, 13, 14, 558, DateTimeKind.Unspecified).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 5, 3, 39, 26, 733, DateTimeKind.Local).AddTicks(7789), new DateTime(2022, 8, 14, 10, 20, 32, 623, DateTimeKind.Unspecified).AddTicks(5797) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 29, 0, 10, 24, 143, DateTimeKind.Local).AddTicks(3883), new DateTime(2022, 8, 21, 18, 0, 24, 402, DateTimeKind.Unspecified).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 14, 17, 31, 13, 4, DateTimeKind.Local).AddTicks(1709), new DateTime(2022, 10, 8, 5, 54, 0, 759, DateTimeKind.Unspecified).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 2, 5, 36, 5, 80, DateTimeKind.Local).AddTicks(1390), new DateTime(2022, 7, 24, 11, 33, 13, 611, DateTimeKind.Unspecified).AddTicks(6051) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 54, 3, 135, DateTimeKind.Local).AddTicks(7509), new DateTime(2022, 11, 2, 20, 21, 34, 458, DateTimeKind.Unspecified).AddTicks(5362) });

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

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1,
                column: "DifficultyLevelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2,
                column: "DifficultyLevelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 5,
                column: "DifficultyLevelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 7,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
