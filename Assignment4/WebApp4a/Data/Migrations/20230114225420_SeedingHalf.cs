using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class SeedingHalf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

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
                name: "FK_Option_Question_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevelId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "CountryId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", 0, "99094eb9-712d-44d3-a46a-3f63b539bbc2", "admin2@gmail.com", false, false, null, null, null, null, "1234567890", false, "b36f9ea6-2448-446e-a09b-37ac1a263472", false, "Admin2" },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", 0, "2a266ef0-f116-49b7-95ee-ac2de2fdbd00", "admin0@gmail.com", false, false, null, null, null, null, "1234567890", false, "be1ace94-f799-44fd-b946-014d6fdf71a1", false, "Admin0" },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", 0, "4eeb9621-c141-4da1-99d8-9e6dbd8a57ba", "admin1@gmail.com", false, false, null, null, null, null, "1234567890", false, "8249df9a-76ff-4f45-97c8-f08bee44e264", false, "Admin1" },
                    { "f60a904a-aba6-4635-892d-f38919b09896", 0, "afea8d14-c41b-4160-b6b8-b7be04950d29", "admin3@gmail.com", false, false, null, null, null, null, "1234567890", false, "6ccb4740-df0d-4a94-8f31-33b82265cad3", false, "Admin3" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryOfResidence" },
                values: new object[,]
                {
                    { 1, "Saint Lucia" },
                    { 2, "Yemen" },
                    { 3, "Mexico" },
                    { 4, "United Arab Emirates" },
                    { 5, "Liechtenstein" },
                    { 6, "Bahrain" },
                    { 7, "Costa Rica" },
                    { 8, "Norfolk Island" },
                    { 9, "Monaco" },
                    { 10, "Yemen" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Difficulty" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 }
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
                values: new object[,]
                {
                    { 1, 26, "System.String[]" },
                    { 2, 35, "System.String[]" },
                    { 3, 29, "System.String[]" },
                    { 4, 27, "System.String[]" },
                    { 5, 35, "System.String[]" },
                    { 6, 40, "System.String[]" },
                    { 7, 27, "System.String[]" },
                    { 8, 35, "System.String[]" },
                    { 9, 35, "System.String[]" },
                    { 10, 26, "System.String[]" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "CandidateAppUserId", "City", "CountryId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "66095 Lynch Pine", "68310 Schneider Inlet", null, "Port Rowena", 1, "68826-2859", "New Mexico" },
                    { 2, "0572 Annabelle Stream", "0751 Cormier Pass", null, "South Madgeport", 2, "59877-3334", "Georgia" },
                    { 3, "51466 Klein Station", "85018 Jordi Flats", null, "East Angelborough", 3, "82709", "Florida" },
                    { 4, "23758 Estella Inlet", "14592 Stehr Street", null, "East Janiceborough", 4, "42369", "New Hampshire" },
                    { 5, "3185 Daugherty Avenue", "2243 White Drive", null, "South Lonnie", 5, "69677-1704", "South Carolina" },
                    { 6, "687 Jada Crest", "651 Albina Tunnel", null, "Port Velva", 6, "13970-2364", "West Virginia" },
                    { 7, "997 Tiana Pike", "948 MacGyver Fords", null, "Goyetteland", 7, "28047", "Nevada" },
                    { 8, "41895 Carroll Lock", "591 Julia Flat", null, "West Thea", 8, "92910-9490", "Maine" },
                    { 9, "930 Madalyn Cape", "8263 Spencer Via", null, "Gutkowskichester", 9, "82779", "North Carolina" },
                    { 10, "68421 Rico Mews", "9546 Romaguera Lakes", null, "West Nathanielmouth", 10, "12449", "Pennsylvania" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "AppUserId", "CandidateNumber", "DateOfBirth", "Email", "FirstName", "GenderId", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber", "PhotoIdTypeId" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "193265026", new DateTime(1979, 9, 20, 19, 23, 31, 404, DateTimeKind.Local).AddTicks(3920), "Marlen.Schmitt50@gmail.com", "Alize", 1, "821.492.5512 x6071", 1, "Hansen", "Esther", "(957) 964-6282", new DateTime(2018, 3, 3, 15, 57, 45, 814, DateTimeKind.Local).AddTicks(2999), "ꡰ騹�持昚憮", 3 },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "419272734", new DateTime(1996, 11, 9, 12, 42, 52, 985, DateTimeKind.Local).AddTicks(2253), "Cordie_Sawayn64@hotmail.com", "Donna", 2, "1-864-658-6163", 3, "Zboncak", "Josianne", "230.942.2510", new DateTime(2019, 6, 26, 4, 32, 47, 546, DateTimeKind.Local).AddTicks(4790), "藞專誢", 3 },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "353153592", new DateTime(2009, 5, 16, 8, 34, 53, 479, DateTimeKind.Local).AddTicks(9739), "Ashtyn.Howe@gmail.com", "Gregory", 4, "282-355-5754", 3, "Friesen", "Gladyce", "649.475.1379", new DateTime(2021, 9, 18, 21, 49, 0, 678, DateTimeKind.Local).AddTicks(6484), "቉뼫䞅辢j�", 5 }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "DifficultyLevelId", "Text", "TopicId" },
                values: new object[,]
                {
                    { 1, 2, "<h1>this is question</h1>", 5 },
                    { 2, 2, "<h3>this is question</h3>", 1 },
                    { 3, 1, "<h1>this is question</h1>", 10 },
                    { 4, 3, "<h1>this is question</h1>", 7 },
                    { 5, 1, "<h1>this is question</h1>", 5 },
                    { 6, 1, "<h1>this is question</h1>", 9 },
                    { 7, 3, "<h1>this is question</h1>", 9 },
                    { 8, 1, "<h2>this is question</h2>", 2 },
                    { 9, 2, "<h1>this is question</h1>", 3 },
                    { 10, 2, "<h1>this is question</h1>", 6 }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Correct", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "<h1>this is an option</h1>" },
                    { 2, false, 2, "<h1>this is an option</h1>" },
                    { 3, false, 8, "<h1>this is an option</h1>" },
                    { 4, false, 6, "<h2>this is an option</h2>" },
                    { 5, false, 1, "<h2>this is an option</h2>" },
                    { 6, false, 5, "<h1>this is an option</h1>" },
                    { 7, false, 6, "<h1>this is an option</h1>" },
                    { 8, false, 5, "<h2>this is an option</h2>" },
                    { 9, false, 7, "<h1>this is an option</h1>" },
                    { 10, false, 6, "<h1>this is an option</h1>" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

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
                name: "FK_Option_Question_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_DifficultyLevels_DifficultyLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topics_TopicId",
                table: "Question");

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
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8);

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
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotoIdTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Topics",
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
                table: "DifficultyLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Option",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
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
