using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class fullSeed_non_relational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Languages_LanguageId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_PhotoIdTypes_PhotoIdTypeId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CandidateAppUserId",
                table: "CandidateExams");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameColumn(
                name: "CandidateAppUserId",
                table: "Addresses",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CandidateAppUserId",
                table: "Addresses",
                newName: "IX_Addresses_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TopicId",
                table: "Questions",
                newName: "IX_Questions_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_DifficultyLevelId",
                table: "Questions",
                newName: "IX_Questions_DifficultyLevelId");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Option",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CertificateId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoIdTypeId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevelId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", 0, "b90eaff4-a593-4647-b144-d531397ba900", "admin2@gmail.com", false, false, null, null, null, null, "1234567890", false, "e5a94cb2-f585-421a-8deb-acf7dde77dc6", false, "Admin2" },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", 0, "7594f323-827a-448b-8bdf-605beec8f614", "admin0@gmail.com", false, false, null, null, null, null, "1234567890", false, "6ad2f95c-3fb3-4bf5-aa52-dcadce4779ee", false, "Admin0" },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", 0, "050f94f7-269b-4c1e-8b54-c1e72ddbe449", "admin1@gmail.com", false, false, null, null, null, null, "1234567890", false, "6e1aeac1-355d-4157-8307-bf881c07654c", false, "Admin1" },
                    { "f60a904a-aba6-4635-892d-f38919b09896", 0, "f9faf7c0-3cd3-4092-baae-6aa37a11d11e", "admin3@gmail.com", false, false, null, null, null, null, "1234567890", false, "80c6714c-0738-4cb9-b2f2-f950db5efd43", false, "Admin3" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Active", "Category", "Description", "PassingMark", "Title" },
                values: new object[,]
                {
                    { 1, false, "reinvent", "CSS Legacy AI Secured Guinea-Bissau SAS non-volatile Brunei Darussalam Rustic Berkshire", 0, "mobile interfaces revolutionize" },
                    { 2, false, "asymmetric", "index Designer bypass JBOD world-class Landing invoice open-source Human invoice", 0, "SAS conglomeration Incredible Plastic Tuna" },
                    { 3, false, "Berkshire", "Small Cotton Keyboard bandwidth empower Handmade Steel Bike Wooden neural parse TCP Incredible open architecture", 0, "Ranch Antigua and Barbuda Infrastructure" },
                    { 4, false, "synthesizing", "Coves web-enabled ADP Mobility Metal Checking Account Security Personal Loan Account Cayman Islands Central", 0, "Malaysia AGP Unbranded Cotton Keyboard" },
                    { 5, false, "Paradigm", "Cambridgeshire orchestration Manager Latvian Lats Tasty Rubber Keyboard Drive Refined Concrete Cheese functionalities Assurance Lead", 0, "withdrawal metrics copy" },
                    { 6, true, "back up", "Points Forint methodologies Chief convergence Incredible Plastic Ball Route primary withdrawal copying", 0, "extensible Investment Account Drives" },
                    { 7, true, "hack", "Wyoming Liaison Guam Suriname haptic Infrastructure ivory payment Kids multi-byte", 0, "synthesize frictionless AI" },
                    { 8, false, "Barbados Dollar", "New Mexico California Money Market Account orchestrate Fantastic Plastic Bike JSON Forward Iowa Crescent deposit", 0, "Fresh deposit withdrawal" },
                    { 9, false, "bleeding-edge", "Drives Virgin Islands, U.S. clicks-and-mortar Wooden database CSS hybrid customized full-range B2B", 0, "transmit deposit payment" },
                    { 10, false, "Orchestrator", "Pitcairn Islands Fantastic Metal Pizza Fantastic Frozen Towels index Gorgeous Fresh Cheese Central Montana COM Progressive harness", 0, "withdrawal Central Synchronised" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryOfResidence" },
                values: new object[,]
                {
                    { 1, "Yemen" },
                    { 2, "Mexico" },
                    { 3, "United Arab Emirates" },
                    { 4, "Liechtenstein" },
                    { 5, "Bahrain" },
                    { 6, "Costa Rica" },
                    { 7, "Norfolk Island" },
                    { 8, "Monaco" },
                    { 9, "Yemen" },
                    { 10, "Ethiopia" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Difficulty" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "NativeLanguage" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Greek" },
                    { 3, "Russian" },
                    { 4, "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "PhotoIdTypes",
                columns: new[] { "Id", "IdType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "MaxMarks", "Name" },
                values: new object[] { 1, 26, "Sports & Music firewall input" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "MaxMarks", "Name" },
                values: new object[,]
                {
                    { 2, 25, "withdrawal synergize Movies & Clothing" },
                    { 3, 29, "Human Philippine Peso Lead" },
                    { 4, 37, "Lead back-end Agent" },
                    { 5, 31, "capacity Parkways real-time" },
                    { 6, 37, "Brunei Darussalam Associate Corporate" },
                    { 7, 31, "Rupiah Island Small Cotton Car" },
                    { 8, 39, "deploy bluetooth connecting" },
                    { 9, 31, "Money Market Account connect Gorgeous" },
                    { 10, 35, "transmit International scale" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "AppUserId", "CandidateNumber", "DateOfBirth", "Email", "FirstName", "GenderId", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber", "PhotoIdTypeId" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "153060623", new DateTime(1956, 1, 6, 19, 31, 31, 457, DateTimeKind.Local).AddTicks(1897), "Kory27@gmail.com", "Dakota", 4, "(210) 799-5764 x6282", 1, "Wilkinson", "Bridie", "1-783-633-4424", new DateTime(2022, 9, 15, 7, 18, 22, 739, DateTimeKind.Local).AddTicks(4609), "f1lklm", 3 },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "420088571", new DateTime(1991, 11, 5, 17, 54, 53, 854, DateTimeKind.Local).AddTicks(7227), "Otho_Pfannerstill31@gmail.com", "Josianne", 2, "645.786.1631 x0930", 2, "Pfeffer", "Yolanda", "351-303-5993 x592", new DateTime(2022, 2, 25, 19, 40, 16, 372, DateTimeKind.Local).AddTicks(2836), "bfqee8", 4 },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "136721276", new DateTime(1988, 7, 20, 17, 9, 51, 729, DateTimeKind.Local).AddTicks(6613), "Dedrick_Lynch@hotmail.com", "Adeline", 4, "615.524.9751 x3792", 2, "Dietrich", "Aiyana", "(750) 481-1897", new DateTime(2018, 1, 10, 6, 1, 58, 154, DateTimeKind.Local).AddTicks(3276), "cb4osy", 5 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CertificateId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevelId", "Text", "TopicId" },
                values: new object[,]
                {
                    { 1, 3, "<h1>this is question</h1>", 1 },
                    { 2, 3, "<h3>this is question</h3>", 3 },
                    { 3, 1, "<h1>this is question</h1>", 8 },
                    { 4, 4, "<h1>this is question</h1>", 5 },
                    { 5, 3, "<h1>this is question</h1>", 1 },
                    { 6, 2, "<h3>this is question</h3>", 2 },
                    { 7, 4, "<h2>this is question</h2>", 2 },
                    { 8, 4, "<h3>this is question</h3>", 2 },
                    { 9, 3, "<h1>this is question</h1>", 5 },
                    { 10, 4, "<h1>this is question</h1>", 6 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "CandidateId", "City", "CountryId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "831 Heller Place", "9688 Stark Place", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "New Demond", 1, "95510-8057", "Vermont" },
                    { 2, "5075 Karl Curve", "19598 Madge Mission", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Ritchieborough", 2, "48284", "Louisiana" },
                    { 3, "6314 Jenifer Plains", "18120 Leannon Club", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "East Jeff", 3, "70911", "Vermont" },
                    { 4, "7589 Dejon Heights", "459 Skiles Crossroad", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "East Cristalview", 4, "14236-9757", "Louisiana" },
                    { 5, "51359 Chet Trail", "34678 Jess Hill", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "Valentinafurt", 5, "17049-9241", "Oregon" },
                    { 6, "308 Ferry Ridges", "9991 Fay Walk", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Port Nelson", 6, "36477", "Alaska" },
                    { 7, "708 Zieme Village", "8821 Toby Land", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Heathville", 7, "47627", "Tennessee" },
                    { 8, "9589 Bryana Stream", "1449 Laney Underpass", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "South Ursula", 8, "10949-0483", "Hawaii" },
                    { 9, "44989 Hodkiewicz Brook", "37608 Harber Stream", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Lake Nina", 9, "30846", "Virginia" },
                    { 10, "5974 Chandler Parkway", "3757 Margie Brook", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "East Delaneybury", 10, "08208-7354", "Mississippi" }
                });

            migrationBuilder.InsertData(
                table: "CandidateExams",
                columns: new[] { "Id", "AssessmentCode", "CandidateId", "CandidateScore", "ExamDate", "ExamId", "MaxScore", "PercentScore", "ReportDate", "Result" },
                values: new object[,]
                {
                    { 1, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 17, 22, 16, 49, 966, DateTimeKind.Local).AddTicks(8168), 7, null, null, new DateTime(2022, 9, 17, 16, 9, 20, 748, DateTimeKind.Unspecified).AddTicks(4282), null },
                    { 2, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 12, 26, 7, 56, 51, 896, DateTimeKind.Local).AddTicks(9514), 4, null, null, new DateTime(2022, 12, 25, 14, 53, 1, 394, DateTimeKind.Unspecified).AddTicks(4259), null },
                    { 3, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2022, 6, 21, 22, 19, 29, 205, DateTimeKind.Local).AddTicks(5008), 6, null, null, new DateTime(2022, 12, 1, 2, 59, 37, 971, DateTimeKind.Unspecified).AddTicks(1103), null },
                    { 4, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 10, 3, 4, 49, 252, DateTimeKind.Local).AddTicks(5820), 7, null, null, new DateTime(2022, 11, 15, 13, 56, 10, 790, DateTimeKind.Unspecified).AddTicks(1458), null },
                    { 5, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 6, 21, 15, 35, 41, 193, DateTimeKind.Local).AddTicks(4750), 4, null, null, new DateTime(2022, 10, 16, 22, 4, 55, 751, DateTimeKind.Unspecified).AddTicks(314), null },
                    { 6, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 10, 6, 10, 16, 44, 900, DateTimeKind.Local).AddTicks(2011), 3, null, null, new DateTime(2022, 8, 14, 19, 27, 36, 955, DateTimeKind.Unspecified).AddTicks(3802), null },
                    { 7, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 12, 30, 6, 47, 42, 309, DateTimeKind.Local).AddTicks(8098), 3, null, null, new DateTime(2022, 8, 22, 4, 8, 40, 586, DateTimeKind.Unspecified).AddTicks(7501), null },
                    { 8, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 4, 16, 0, 8, 31, 170, DateTimeKind.Local).AddTicks(5916), 3, null, null, new DateTime(2022, 10, 8, 22, 39, 23, 747, DateTimeKind.Unspecified).AddTicks(9308), null },
                    { 9, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 5, 3, 12, 13, 23, 246, DateTimeKind.Local).AddTicks(5589), 2, null, null, new DateTime(2022, 7, 24, 17, 45, 8, 324, DateTimeKind.Unspecified).AddTicks(3859), null },
                    { 10, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2022, 9, 13, 0, 31, 21, 302, DateTimeKind.Local).AddTicks(1701), 7, null, null, new DateTime(2022, 11, 3, 16, 41, 1, 281, DateTimeKind.Unspecified).AddTicks(4768), null }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Correct", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "<h2>this is an option</h2>" },
                    { 2, false, 9, "<h2>this is an option</h2>" },
                    { 3, false, 5, "<h1>this is an option</h1>" },
                    { 4, false, 1, "<h1>this is an option</h1>" },
                    { 5, false, 9, "<h3>this is an option</h3>" },
                    { 6, false, 9, "<h3>this is an option</h3>" },
                    { 7, false, 10, "<h2>this is an option</h2>" },
                    { 8, false, 9, "<h1>this is an option</h1>" },
                    { 9, false, 5, "<h3>this is an option</h3>" },
                    { 10, false, 4, "<h3>this is an option</h3>" }
                });

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
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Languages_LanguageId",
                table: "Candidates",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_PhotoIdTypes_PhotoIdTypeId",
                table: "Candidates",
                column: "PhotoIdTypeId",
                principalTable: "PhotoIdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams",
                column: "CertificateId",
                principalTable: "Certificates",
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
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                table: "CandidateExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Languages_LanguageId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_PhotoIdTypes_PhotoIdTypeId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896");

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
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75");

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915");

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767");

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767");

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateExams");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Addresses",
                newName: "CandidateAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses",
                newName: "IX_Addresses_CandidateAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TopicId",
                table: "Question",
                newName: "IX_Question_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_DifficultyLevelId",
                table: "Question",
                newName: "IX_Question_DifficultyLevelId");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Option",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CertificateId",
                table: "Exams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoIdTypeId",
                table: "Candidates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Candidates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Candidates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevelId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateAppUserId",
                table: "CandidateExams",
                column: "CandidateAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses",
                column: "CandidateAppUserId",
                principalTable: "Candidates",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Genders_GenderId",
                table: "Candidates",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Languages_LanguageId",
                table: "Candidates",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_PhotoIdTypes_PhotoIdTypeId",
                table: "Candidates",
                column: "PhotoIdTypeId",
                principalTable: "PhotoIdTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }
    }
}
