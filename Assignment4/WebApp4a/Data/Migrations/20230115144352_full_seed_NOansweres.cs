using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class full_seed_NOansweres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTopic_Certificates_CertificatesId",
                table: "CertificateTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTopic_Topics_TopicsId",
                table: "CertificateTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "ExamQuestion",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_QuestionsId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_QuestionId");

            migrationBuilder.RenameColumn(
                name: "TopicsId",
                table: "CertificateTopic",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "CertificatesId",
                table: "CertificateTopic",
                newName: "CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificateTopic_TopicsId",
                table: "CertificateTopic",
                newName: "IX_CertificateTopic_TopicId");

            migrationBuilder.RenameColumn(
                name: "CandidateAppUserId",
                table: "Addresses",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CandidateAppUserId",
                table: "Addresses",
                newName: "IX_Addresses_CandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "CertificateId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "831 Heller Place", "9688 Stark Place", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "New Demond", "95510-8057", "Vermont" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "5075 Karl Curve", "19598 Madge Mission", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Ritchieborough", "48284", "Louisiana" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "6314 Jenifer Plains", "18120 Leannon Club", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "East Jeff", "70911", "Vermont" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "7589 Dejon Heights", "459 Skiles Crossroad", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "East Cristalview", "14236-9757", "Louisiana" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "51359 Chet Trail", "34678 Jess Hill", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "Valentinafurt", "17049-9241", "Oregon" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "308 Ferry Ridges", "9991 Fay Walk", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Port Nelson", "36477", "Alaska" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "708 Zieme Village", "8821 Toby Land", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Heathville", "47627", "Tennessee" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "9589 Bryana Stream", "1449 Laney Underpass", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "South Ursula", "10949-0483", "Hawaii" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "44989 Hodkiewicz Brook", "37608 Harber Stream", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Lake Nina", "30846", "Virginia" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address1", "Address2", "CandidateId", "City", "PostalCode", "State" },
                values: new object[] { "5974 Chandler Parkway", "3757 Margie Brook", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "East Delaneybury", "08208-7354", "Mississippi" });

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
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "GenderId", "Landline", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber" },
                values: new object[] { "153060623", new DateTime(1956, 1, 5, 11, 45, 7, 868, DateTimeKind.Local).AddTicks(7187), "Kory27@gmail.com", "Dakota", 4, "(210) 799-5764 x6282", "Wilkinson", "Bridie", "1-783-633-4424", new DateTime(2022, 9, 13, 23, 31, 59, 150, DateTimeKind.Local).AddTicks(9901), "f1lklm" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber", "PhotoIdTypeId" },
                values: new object[] { "420088571", new DateTime(1991, 11, 4, 10, 8, 30, 266, DateTimeKind.Local).AddTicks(2362), "Otho_Pfannerstill31@gmail.com", "Josianne", "645.786.1631 x0930", 2, "Pfeffer", "Yolanda", "351-303-5993 x592", new DateTime(2022, 2, 24, 11, 53, 52, 783, DateTimeKind.Local).AddTicks(7998), "bfqee8", 4 });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber" },
                values: new object[] { "136721276", new DateTime(1988, 7, 19, 9, 23, 28, 141, DateTimeKind.Local).AddTicks(1876), "Dedrick_Lynch@hotmail.com", "Adeline", "615.524.9751 x3792", 2, "Dietrich", "Aiyana", "(750) 481-1897", new DateTime(2018, 1, 8, 22, 15, 34, 565, DateTimeKind.Local).AddTicks(8544), "cb4osy" });

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

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountryOfResidence",
                value: "Yemen");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CountryOfResidence",
                value: "Mexico");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CountryOfResidence",
                value: "United Arab Emirates");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CountryOfResidence",
                value: "Liechtenstein");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CountryOfResidence",
                value: "Bahrain");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CountryOfResidence",
                value: "Costa Rica");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CountryOfResidence",
                value: "Norfolk Island");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CountryOfResidence",
                value: "Monaco");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CountryOfResidence",
                value: "Yemen");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CountryOfResidence",
                value: "Ethiopia");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<h2>this is an option</h2>");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 9, "<h2>this is an option</h2>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 1, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 9, "<h3>this is an option</h3>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 9, "<h3>this is an option</h3>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 10, "<h2>this is an option</h2>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 9, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 5, "<h3>this is an option</h3>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 4, "<h3>this is an option</h3>" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1,
                column: "TopicId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2,
                column: "TopicId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 3,
                column: "TopicId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4,
                column: "TopicId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DifficultyLevelId", "TopicId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DifficultyLevelId", "Text", "TopicId" },
                values: new object[] { 2, "<h3>this is question</h3>", 2 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Text", "TopicId" },
                values: new object[] { "<h2>this is question</h2>", 2 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DifficultyLevelId", "Text" },
                values: new object[] { 3, "<h3>this is question</h3>" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DifficultyLevelId", "TopicId" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10,
                column: "DifficultyLevelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sports & Music firewall input");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 25, "withdrawal synergize Movies & Clothing" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Human Philippine Peso Lead");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 37, "Lead back-end Agent" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 31, "capacity Parkways real-time" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 37, "Brunei Darussalam Associate Corporate" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 31, "Rupiah Island Small Cotton Car" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 39, "deploy bluetooth connecting" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 31, "Money Market Account connect Gorgeous" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 35, "transmit International scale" });

            migrationBuilder.InsertData(
                table: "CertificateTopic",
                columns: new[] { "CertificateId", "TopicId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 4 }
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
                table: "ExamQuestion",
                columns: new[] { "ExamsId", "QuestionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTopic_Certificates_CertificateId",
                table: "CertificateTopic",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTopic_Topics_TopicId",
                table: "CertificateTopic",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Candidates_CandidateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTopic_Certificates_CertificateId",
                table: "CertificateTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTopic_Topics_TopicId",
                table: "CertificateTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams");

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CertificateTopic",
                keyColumns: new[] { "CertificateId", "TopicId" },
                keyValues: new object[] { 3, 4 });

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
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ExamQuestion",
                keyColumns: new[] { "ExamsId", "QuestionId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 7);

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
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ExamQuestion",
                newName: "QuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_QuestionsId");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "CertificateTopic",
                newName: "TopicsId");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "CertificateTopic",
                newName: "CertificatesId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificateTopic_TopicId",
                table: "CertificateTopic",
                newName: "IX_CertificateTopic_TopicsId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Addresses",
                newName: "CandidateAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses",
                newName: "IX_Addresses_CandidateAppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "CertificateId",
                table: "Exams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "66095 Lynch Pine", "68310 Schneider Inlet", null, "Port Rowena", "68826-2859", "New Mexico" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "0572 Annabelle Stream", "0751 Cormier Pass", null, "South Madgeport", "59877-3334", "Georgia" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "51466 Klein Station", "85018 Jordi Flats", null, "East Angelborough", "82709", "Florida" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "23758 Estella Inlet", "14592 Stehr Street", null, "East Janiceborough", "42369", "New Hampshire" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "3185 Daugherty Avenue", "2243 White Drive", null, "South Lonnie", "69677-1704", "South Carolina" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "687 Jada Crest", "651 Albina Tunnel", null, "Port Velva", "13970-2364", "West Virginia" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "997 Tiana Pike", "948 MacGyver Fords", null, "Goyetteland", "28047", "Nevada" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "41895 Carroll Lock", "591 Julia Flat", null, "West Thea", "92910-9490", "Maine" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "930 Madalyn Cape", "8263 Spencer Via", null, "Gutkowskichester", "82779", "North Carolina" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address1", "Address2", "CandidateAppUserId", "City", "PostalCode", "State" },
                values: new object[] { "68421 Rico Mews", "9546 Romaguera Lakes", null, "West Nathanielmouth", "12449", "Pennsylvania" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99094eb9-712d-44d3-a46a-3f63b539bbc2", "b36f9ea6-2448-446e-a09b-37ac1a263472" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a266ef0-f116-49b7-95ee-ac2de2fdbd00", "be1ace94-f799-44fd-b946-014d6fdf71a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4eeb9621-c141-4da1-99d8-9e6dbd8a57ba", "8249df9a-76ff-4f45-97c8-f08bee44e264" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f60a904a-aba6-4635-892d-f38919b09896",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "afea8d14-c41b-4160-b6b8-b7be04950d29", "6ccb4740-df0d-4a94-8f31-33b82265cad3" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "8ca319b2-762d-45e3-8b26-edd6b1f4ba75",
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "GenderId", "Landline", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber" },
                values: new object[] { "193265026", new DateTime(1979, 9, 20, 19, 23, 31, 404, DateTimeKind.Local).AddTicks(3920), "Marlen.Schmitt50@gmail.com", "Alize", 1, "821.492.5512 x6071", "Hansen", "Esther", "(957) 964-6282", new DateTime(2018, 3, 3, 15, 57, 45, 814, DateTimeKind.Local).AddTicks(2999), "ꡰ騹�持昚憮" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "9407b6e2-f46e-4a79-a725-dfb1e15e2915",
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber", "PhotoIdTypeId" },
                values: new object[] { "419272734", new DateTime(1996, 11, 9, 12, 42, 52, 985, DateTimeKind.Local).AddTicks(2253), "Cordie_Sawayn64@hotmail.com", "Donna", "1-864-658-6163", 3, "Zboncak", "Josianne", "230.942.2510", new DateTime(2019, 6, 26, 4, 32, 47, 546, DateTimeKind.Local).AddTicks(4790), "藞專誢", 3 });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "AppUserId",
                keyValue: "be69a4bd-fb90-41dd-b65b-4ff8b619b767",
                columns: new[] { "CandidateNumber", "DateOfBirth", "Email", "FirstName", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber" },
                values: new object[] { "353153592", new DateTime(2009, 5, 16, 8, 34, 53, 479, DateTimeKind.Local).AddTicks(9739), "Ashtyn.Howe@gmail.com", "Gregory", "282-355-5754", 3, "Friesen", "Gladyce", "649.475.1379", new DateTime(2021, 9, 18, 21, 49, 0, 678, DateTimeKind.Local).AddTicks(6484), "቉뼫䞅辢j�" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountryOfResidence",
                value: "Saint Lucia");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CountryOfResidence",
                value: "Yemen");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CountryOfResidence",
                value: "Mexico");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CountryOfResidence",
                value: "United Arab Emirates");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CountryOfResidence",
                value: "Liechtenstein");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CountryOfResidence",
                value: "Bahrain");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CountryOfResidence",
                value: "Costa Rica");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CountryOfResidence",
                value: "Norfolk Island");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CountryOfResidence",
                value: "Monaco");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CountryOfResidence",
                value: "Yemen");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<h1>this is an option</h1>");

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 2, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 6, "<h2>this is an option</h2>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 1, "<h2>this is an option</h2>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 5, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 6, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 5, "<h2>this is an option</h2>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 7, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "QuestionId", "Text" },
                values: new object[] { 6, "<h1>this is an option</h1>" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1,
                column: "TopicId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2,
                column: "TopicId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 3,
                column: "TopicId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4,
                column: "TopicId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DifficultyLevelId", "TopicId" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DifficultyLevelId", "Text", "TopicId" },
                values: new object[] { 1, "<h1>this is question</h1>", 9 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Text", "TopicId" },
                values: new object[] { "<h1>this is question</h1>", 9 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DifficultyLevelId", "Text" },
                values: new object[] { 1, "<h2>this is question</h2>" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DifficultyLevelId", "TopicId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10,
                column: "DifficultyLevelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "System.String[]");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 35, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "System.String[]");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 27, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 35, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 40, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 27, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 35, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 35, "System.String[]" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MaxMarks", "Name" },
                values: new object[] { 26, "System.String[]" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Candidates_CandidateAppUserId",
                table: "Addresses",
                column: "CandidateAppUserId",
                principalTable: "Candidates",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTopic_Certificates_CertificatesId",
                table: "CertificateTopic",
                column: "CertificatesId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTopic_Topics_TopicsId",
                table: "CertificateTopic",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
