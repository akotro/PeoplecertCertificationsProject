using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class added_MaxMark_to_Certificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxMark",
                table: "Certificates",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxMark",
                table: "Certificates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b90eaff4-a593-4647-b144-d531397ba900", "e5a94cb2-f585-421a-8deb-acf7dde77dc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7594f323-827a-448b-8bdf-605beec8f614", "6ad2f95c-3fb3-4bf5-aa52-dcadce4779ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "050f94f7-269b-4c1e-8b54-c1e72ddbe449", "6e1aeac1-355d-4157-8307-bf881c07654c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f9faf7c0-3cd3-4092-baae-6aa37a11d11e", "80c6714c-0738-4cb9-b2f2-f950db5efd43" });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 17, 22, 16, 49, 966, DateTimeKind.Local).AddTicks(8168), new DateTime(2022, 9, 17, 16, 9, 20, 748, DateTimeKind.Unspecified).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 26, 7, 56, 51, 896, DateTimeKind.Local).AddTicks(9514), new DateTime(2022, 12, 25, 14, 53, 1, 394, DateTimeKind.Unspecified).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 6, 21, 22, 19, 29, 205, DateTimeKind.Local).AddTicks(5008), new DateTime(2022, 12, 1, 2, 59, 37, 971, DateTimeKind.Unspecified).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 10, 3, 4, 49, 252, DateTimeKind.Local).AddTicks(5820), new DateTime(2022, 11, 15, 13, 56, 10, 790, DateTimeKind.Unspecified).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 6, 21, 15, 35, 41, 193, DateTimeKind.Local).AddTicks(4750), new DateTime(2022, 10, 16, 22, 4, 55, 751, DateTimeKind.Unspecified).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 10, 6, 10, 16, 44, 900, DateTimeKind.Local).AddTicks(2011), new DateTime(2022, 8, 14, 19, 27, 36, 955, DateTimeKind.Unspecified).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 12, 30, 6, 47, 42, 309, DateTimeKind.Local).AddTicks(8098), new DateTime(2022, 8, 22, 4, 8, 40, 586, DateTimeKind.Unspecified).AddTicks(7501) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 4, 16, 0, 8, 31, 170, DateTimeKind.Local).AddTicks(5916), new DateTime(2022, 10, 8, 22, 39, 23, 747, DateTimeKind.Unspecified).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2021, 5, 3, 12, 13, 23, 246, DateTimeKind.Local).AddTicks(5589), new DateTime(2022, 7, 24, 17, 45, 8, 324, DateTimeKind.Unspecified).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "CandidateExams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExamDate", "ReportDate" },
                values: new object[] { new DateTime(2022, 9, 13, 0, 31, 21, 302, DateTimeKind.Local).AddTicks(1701), new DateTime(2022, 11, 3, 16, 41, 1, 281, DateTimeKind.Unspecified).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1956, 1, 6, 19, 31, 31, 457, DateTimeKind.Local).AddTicks(1897), new DateTime(2022, 9, 15, 7, 18, 22, 739, DateTimeKind.Local).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1991, 11, 5, 17, 54, 53, 854, DateTimeKind.Local).AddTicks(7227), new DateTime(2022, 2, 25, 19, 40, 16, 372, DateTimeKind.Local).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "DateOfBirth", "PhotoIdIssueDate" },
                values: new object[] { new DateTime(1988, 7, 20, 17, 9, 51, 729, DateTimeKind.Local).AddTicks(6613), new DateTime(2018, 1, 10, 6, 1, 58, 154, DateTimeKind.Local).AddTicks(3276) });
        }
    }
}
