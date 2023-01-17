using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class options_added_and_questinon_notnull_test : Migration
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42d15506-0b2e-423d-bb00-4cfab094aeae", "7a411ba5-f26d-4fe6-95c6-dee56f1924b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed79bc43-6ffc-4448-b398-f33043f41460", "7b3d8e06-5602-4507-897a-fbd015b92805" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aad58249-46ba-4cc3-85e5-89883c85af8a", "96abebd1-3035-4909-a8f0-d4548e3d7bcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ad34fd7-017d-4e2d-bee0-2553b377eaac", "d4e4367c-1b6f-4568-9ad0-a89b543b0c99" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 18, 9, 44, 30, 930, DateTimeKind.Local).AddTicks(7579), new DateTime(2022, 9, 17, 21, 19, 28, 77, DateTimeKind.Unspecified).AddTicks(2712) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 26, 19, 24, 32, 860, DateTimeKind.Local).AddTicks(8901), new DateTime(2022, 12, 26, 1, 11, 0, 490, DateTimeKind.Unspecified).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 22, 9, 47, 10, 169, DateTimeKind.Local).AddTicks(4397), new DateTime(2022, 12, 1, 12, 1, 24, 179, DateTimeKind.Unspecified).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 10, 14, 32, 30, 216, DateTimeKind.Local).AddTicks(5210), new DateTime(2022, 11, 15, 22, 9, 35, 178, DateTimeKind.Unspecified).AddTicks(7654) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 22, 3, 3, 22, 157, DateTimeKind.Local).AddTicks(4141), new DateTime(2022, 10, 17, 4, 46, 2, 998, DateTimeKind.Unspecified).AddTicks(2273) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 6, 21, 44, 25, 864, DateTimeKind.Local).AddTicks(1403), new DateTime(2022, 8, 14, 22, 52, 22, 750, DateTimeKind.Unspecified).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 30, 18, 15, 23, 273, DateTimeKind.Local).AddTicks(7490), new DateTime(2022, 8, 22, 7, 56, 20, 717, DateTimeKind.Unspecified).AddTicks(3762) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 16, 11, 36, 12, 134, DateTimeKind.Local).AddTicks(5309), new DateTime(2022, 10, 9, 4, 55, 41, 995, DateTimeKind.Unspecified).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 3, 23, 41, 4, 210, DateTimeKind.Local).AddTicks(4984), new DateTime(2022, 7, 24, 20, 4, 20, 482, DateTimeKind.Unspecified).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 13, 11, 59, 2, 266, DateTimeKind.Local).AddTicks(1096), new DateTime(2022, 11, 4, 0, 17, 26, 838, DateTimeKind.Unspecified).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 7, 6, 59, 12, 419, DateTimeKind.Local).AddTicks(1491), new DateTime(2022, 9, 15, 18, 46, 3, 701, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 6, 5, 22, 34, 816, DateTimeKind.Local).AddTicks(6874), new DateTime(2022, 2, 26, 7, 7, 57, 334, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 21, 4, 37, 32, 691, DateTimeKind.Local).AddTicks(6234), new DateTime(2018, 1, 10, 17, 29, 39, 116, DateTimeKind.Local).AddTicks(2897) });

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bf40999-f2d8-4d13-a878-df40866d03c9", "06a74940-3fb2-4dd0-b02d-8ef147e4566b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f2d9f618-7700-482c-8891-2058f2a6ee69", "0b9cc35b-cfd9-41ea-9010-43117d21e21d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a88d600e-76c5-4aff-96d6-18603245d42d", "87972167-2451-4f97-9025-7e99e49414af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac7fdbb6-4ee6-475a-9bac-e644b62b8048", "fd746ada-6e8d-4e0a-9701-08d41bf640d0" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 17, 23, 9, 18, 640, DateTimeKind.Local).AddTicks(6534), new DateTime(2022, 9, 17, 16, 33, 0, 696, DateTimeKind.Unspecified).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 26, 8, 49, 20, 570, DateTimeKind.Local).AddTicks(7896), new DateTime(2022, 12, 25, 15, 40, 10, 944, DateTimeKind.Unspecified).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 21, 23, 11, 57, 879, DateTimeKind.Local).AddTicks(3396), new DateTime(2022, 12, 1, 3, 40, 58, 559, DateTimeKind.Unspecified).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 10, 3, 57, 17, 926, DateTimeKind.Local).AddTicks(4261), new DateTime(2022, 11, 15, 14, 33, 49, 936, DateTimeKind.Unspecified).AddTicks(6907) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 21, 16, 28, 9, 867, DateTimeKind.Local).AddTicks(3195), new DateTime(2022, 10, 16, 22, 35, 32, 351, DateTimeKind.Unspecified).AddTicks(6467) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 6, 11, 9, 13, 574, DateTimeKind.Local).AddTicks(460), new DateTime(2022, 8, 14, 19, 43, 14, 499, DateTimeKind.Unspecified).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 30, 7, 40, 10, 983, DateTimeKind.Local).AddTicks(6550), new DateTime(2022, 8, 22, 4, 26, 3, 7, DateTimeKind.Unspecified).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 16, 1, 0, 59, 844, DateTimeKind.Local).AddTicks(4371), new DateTime(2022, 10, 8, 23, 8, 6, 721, DateTimeKind.Unspecified).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 3, 13, 5, 51, 920, DateTimeKind.Local).AddTicks(4048), new DateTime(2022, 7, 24, 17, 55, 45, 687, DateTimeKind.Unspecified).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 13, 1, 23, 49, 976, DateTimeKind.Local).AddTicks(163), new DateTime(2022, 11, 3, 17, 15, 51, 106, DateTimeKind.Unspecified).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 6, 20, 24, 0, 128, DateTimeKind.Local).AddTicks(8794), new DateTime(2022, 9, 15, 8, 10, 51, 411, DateTimeKind.Local).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 5, 18, 47, 22, 526, DateTimeKind.Local).AddTicks(3990), new DateTime(2022, 2, 25, 20, 32, 45, 43, DateTimeKind.Local).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 20, 18, 2, 20, 401, DateTimeKind.Local).AddTicks(3484), new DateTime(2018, 1, 10, 6, 54, 26, 826, DateTimeKind.Local).AddTicks(148) });

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
