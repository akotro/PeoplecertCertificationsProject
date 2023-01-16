using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class AddedOptionsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_Option_QuestionId",
                table: "Options",
                newName: "IX_Options_QuestionId");

            migrationBuilder.AlterColumn<bool>(
                name: "Correct",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3d02772c-263e-4c48-8b3d-fc0a00f8403e", "a2d6bfeb-faa5-4bff-aa89-27196ff387c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "480fc984-b61c-4bea-99c8-aeccd43a1c90", "f70f014f-4401-4c3d-8af8-0786586e0fb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46accdc2-5e43-4a39-bd06-808c04a69329", "351a142e-460e-48f0-bf9f-8a8d46ffe66f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6f7c3f8-050a-44a1-b09c-29a95f78d4f9", "ddd8ecdf-3845-449e-99ac-7231c54e03b6" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 17, 22, 27, 13, 316, DateTimeKind.Local).AddTicks(8792), new DateTime(2022, 9, 17, 16, 14, 1, 858, DateTimeKind.Unspecified).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 26, 8, 7, 15, 247, DateTimeKind.Local).AddTicks(466), new DateTime(2022, 12, 25, 15, 2, 21, 566, DateTimeKind.Unspecified).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 21, 22, 29, 52, 555, DateTimeKind.Local).AddTicks(6310), new DateTime(2022, 12, 1, 3, 7, 49, 58, DateTimeKind.Unspecified).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 10, 3, 15, 12, 602, DateTimeKind.Local).AddTicks(7205), new DateTime(2022, 11, 15, 14, 3, 38, 38, DateTimeKind.Unspecified).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 21, 15, 46, 4, 543, DateTimeKind.Local).AddTicks(6167), new DateTime(2022, 10, 16, 22, 10, 59, 347, DateTimeKind.Unspecified).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 6, 10, 27, 8, 250, DateTimeKind.Local).AddTicks(3462), new DateTime(2022, 8, 14, 19, 30, 42, 563, DateTimeKind.Unspecified).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 30, 6, 58, 5, 659, DateTimeKind.Local).AddTicks(9578), new DateTime(2022, 8, 22, 4, 12, 6, 957, DateTimeKind.Unspecified).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 16, 0, 18, 54, 520, DateTimeKind.Local).AddTicks(7419), new DateTime(2022, 10, 8, 22, 45, 4, 848, DateTimeKind.Unspecified).AddTicks(9929) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 3, 12, 23, 46, 596, DateTimeKind.Local).AddTicks(9087), new DateTime(2022, 7, 24, 17, 47, 14, 504, DateTimeKind.Unspecified).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 13, 0, 41, 44, 652, DateTimeKind.Local).AddTicks(5226), new DateTime(2022, 11, 3, 16, 47, 55, 9, DateTimeKind.Unspecified).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 6, 19, 41, 54, 784, DateTimeKind.Local).AddTicks(9517), new DateTime(2022, 9, 15, 7, 28, 46, 67, DateTimeKind.Local).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 5, 18, 5, 17, 182, DateTimeKind.Local).AddTicks(4566), new DateTime(2022, 2, 25, 19, 50, 39, 700, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 20, 17, 20, 15, 57, DateTimeKind.Local).AddTicks(4198), new DateTime(2018, 1, 10, 6, 12, 21, 482, DateTimeKind.Local).AddTicks(866) });

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameIndex(
                name: "IX_Options_QuestionId",
                table: "Option",
                newName: "IX_Option_QuestionId");

            migrationBuilder.AlterColumn<bool>(
                name: "Correct",
                table: "Option",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c19b8db0-f13e-4846-9d12-f6ffdf0f0852", "04543b02-feee-453a-ba42-2817714e2c12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8be6988-75c9-4863-985d-8f17f4e4b606", "36084e42-6902-4a6a-bba4-ed8004372aec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "515783bc-bee3-4c1c-945b-410c46715b7c", "462c1a6e-a841-4271-b1f1-7d72ad212b9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8e3be61-df95-4264-ab9e-9a67b49bbc7c", "ded8e0d8-dd44-492a-b1ed-b87016500f6e" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 17, 18, 38, 51, 920, DateTimeKind.Local).AddTicks(3087), new DateTime(2022, 9, 17, 14, 31, 2, 982, DateTimeKind.Unspecified).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 26, 4, 18, 53, 850, DateTimeKind.Local).AddTicks(4455), new DateTime(2022, 12, 25, 11, 37, 8, 829, DateTimeKind.Unspecified).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 21, 18, 41, 31, 159, DateTimeKind.Local).AddTicks(11), new DateTime(2022, 12, 1, 0, 7, 54, 825, DateTimeKind.Unspecified).AddTicks(9071) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 9, 23, 26, 51, 206, DateTimeKind.Local).AddTicks(887), new DateTime(2022, 11, 15, 11, 19, 47, 403, DateTimeKind.Unspecified).AddTicks(6769) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 21, 11, 57, 43, 146, DateTimeKind.Local).AddTicks(9855), new DateTime(2022, 10, 16, 19, 57, 47, 413, DateTimeKind.Unspecified).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 6, 6, 38, 46, 853, DateTimeKind.Local).AddTicks(7146), new DateTime(2022, 8, 14, 18, 22, 42, 858, DateTimeKind.Unspecified).AddTicks(1627) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 30, 3, 9, 44, 263, DateTimeKind.Local).AddTicks(3267), new DateTime(2022, 8, 22, 2, 56, 30, 881, DateTimeKind.Unspecified).AddTicks(2321) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 15, 20, 30, 33, 124, DateTimeKind.Local).AddTicks(1127), new DateTime(2022, 10, 8, 20, 40, 7, 362, DateTimeKind.Unspecified).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 3, 8, 35, 25, 200, DateTimeKind.Local).AddTicks(815), new DateTime(2022, 7, 24, 17, 1, 1, 30, DateTimeKind.Unspecified).AddTicks(2559) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 12, 20, 53, 23, 255, DateTimeKind.Local).AddTicks(6942), new DateTime(2022, 11, 3, 14, 16, 21, 174, DateTimeKind.Unspecified).AddTicks(1968) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 6, 15, 53, 33, 402, DateTimeKind.Local).AddTicks(5787), new DateTime(2022, 9, 15, 3, 40, 24, 684, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 5, 14, 16, 55, 800, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 2, 25, 16, 2, 18, 317, DateTimeKind.Local).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 20, 13, 31, 53, 675, DateTimeKind.Local).AddTicks(403), new DateTime(2018, 1, 10, 2, 24, 0, 99, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
