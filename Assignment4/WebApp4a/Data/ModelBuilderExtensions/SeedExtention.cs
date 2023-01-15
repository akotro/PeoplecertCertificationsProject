﻿using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using Bogus;
using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Net;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Questions;
using ModelLibrary.Models.Exams;
using System.Security.Cryptography.X509Certificates;

namespace WebApp4a.Data.ModelBuilderExtensions
{
    public static class SeedExtention
    {
        public static void Seed(this ModelBuilder modelBuilder )
        { 

            //public static ModelBuilder sasd = new ModelBuilder();
        //private static ApplicationDbContext _context { get; set; }
        //static SeedExtention (ApplicationDbContext context)
        //{
        //_context = context;
        //}
        //var db = new ApplicationDbContext();


        //SampleData.Initialize(app.ApplicationServices);

        // Bogus RAndomizer set to generate repeatable data sets.
        Randomizer.Seed = new Random(8675309);
            var faker = new Faker();
            var fakeNum10 = faker.Random.Number(1, 10);

            #region // Adding AppUsers

            List<string> fakeGuids = new List<string>();
            fakeGuids.Add("9407b6e2-f46e-4a79-a725-dfb1e15e2915");
            fakeGuids.Add("be69a4bd-fb90-41dd-b65b-4ff8b619b767");
            fakeGuids.Add("8ca319b2-762d-45e3-8b26-edd6b1f4ba75");
            fakeGuids.Add("f60a904a-aba6-4635-892d-f38919b09896");
            List<AppUser> fakeAppUsers = new List<AppUser>();
            for (int i = 0; i < fakeGuids.Count; i++)
            {
                fakeAppUsers.Add(
                    new AppUser()
                    {
                        Id = fakeGuids[i],
                        UserName = $"Admin{i}",
                        Email = $"admin{i}@gmail.com",
                        LockoutEnabled = false,
                        PhoneNumber = "1234567890"
                    });

            }
            for (int j = 0; j < fakeGuids.Count; j++)
            {
                PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                passwordHasher.HashPassword(fakeAppUsers[j], "Admin*123");

            }
            modelBuilder.Entity<AppUser>().HasData(fakeAppUsers);

            #endregion

            #region // Adding Enum options and Seeding Gender Table in DB
            var genderEntries = new List<Gender>();
            for (int i = 0; i < Enum.GetNames(typeof(GenderEnum)).Length; i++)
            {
                var gender = (GenderEnum)Enum.GetValues(typeof(GenderEnum)).GetValue(i);
                genderEntries.Add(new Gender { Id = i + 1, GenderType = gender });
            }
            modelBuilder.Entity<Gender>().HasData(genderEntries);
            #endregion

            #region // Adding Enum options and Seeding PhotoIdType Table in DB
         
            var photoIdTypeEntries = new List<PhotoIdType>();
            for (int i = 0; i < Enum.GetNames(typeof(PhotoIdTypeEnum)).Length; i++)
            {
                var idType = (PhotoIdTypeEnum)Enum.GetValues(typeof(PhotoIdTypeEnum)).GetValue(i);
                photoIdTypeEntries.Add(new PhotoIdType { Id = i + 1, IdType = idType });
            }
            modelBuilder.Entity<PhotoIdType>().HasData(photoIdTypeEntries);

            #endregion

            #region // Adding Enum options and Seeding DifficultyLevels Table in DB
            var difficultyLevelEntries = new List<DifficultyLevel>();
            for (int i = 0; i < Enum.GetNames(typeof(DifficultyEnum)).Length; i++)
            {
                var diffLevel = (DifficultyEnum)Enum.GetValues(typeof(DifficultyEnum)).GetValue(i);
                difficultyLevelEntries.Add(new DifficultyLevel { Id = i + 1, Difficulty = diffLevel });
            }
            modelBuilder.Entity<DifficultyLevel>().HasData(difficultyLevelEntries);

            #endregion

            #region// Seeding Languages table
            var languages = new string[] { "English", "Greek", "Russian", "Chinese" };
            for (int i = 0; i < languages.Length; i++)
            {
                modelBuilder.Entity<Language>().HasData(new { Id = i + 1, NativeLanguage = languages[i] });
            }
            #endregion

            #region// Seeding Countries table
            var countryFaker = new Faker<Country>()
                .RuleFor(u => u.CountryOfResidence, f => f.Address.Country());

            var fakeCountries = countryFaker.Generate(10);
            for (int i = 0; i < fakeCountries.Count; i++)
            {
                fakeCountries[i].Id = i + 1;
                modelBuilder.Entity<Country>().HasData(fakeCountries[i]);
            }
            #endregion

            #region // Seeding Candidate table
            var candidateFaker = new Faker<Candidate>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.MiddleName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Landline, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.CandidateNumber, f => f.Random.Number(100000000, 999999999).ToString())
                .RuleFor(u => u.PhotoIdNumber, f => f.Random.AlphaNumeric(6))
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(100, DateTime.Now))
                .RuleFor(u => u.PhotoIdIssueDate, f => f.Date.Past(10, DateTime.Now))
                .RuleFor(u => u.GenderId, f => f.Random.Number(1, genderEntries.Count))
                .RuleFor(u => u.PhotoIdTypeId, f => f.Random.Number(1, photoIdTypeEntries.Count))
                .RuleFor(u => u.LanguageId, f => f.Random.Number(1, languages.Length));

            var fakeCandidates = candidateFaker.Generate(fakeAppUsers.Count - 1);
            for (int i = 0; i < fakeCandidates.Count; i++)
            {
                fakeCandidates[i].AppUserId = fakeAppUsers[i].Id;
            }

            modelBuilder.Entity<Candidate>().HasData(fakeCandidates);
            #endregion

            #region// Seeding Addresses table
            var addressFaker = new Faker<ModelLibrary.Models.Candidates.Address>()
                .RuleFor(u => u.Address1, f => f.Address.StreetAddress())
                .RuleFor(u => u.Address2, f => f.Address.StreetAddress())
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.PostalCode, f => f.Address.ZipCode());

            var fakeAddresses = addressFaker.Generate(10);
            for (int i = 0; i < fakeAddresses.Count; i++)
            {
                fakeAddresses[i].Id = i + 1;
                fakeAddresses[i].CountryId = fakeCountries[i].Id;
                fakeAddresses[i].CandidateId = fakeCandidates[faker.Random.Number(fakeCandidates.Count-1)].AppUserId;
            }

            modelBuilder.Entity<ModelLibrary.Models.Candidates.Address>().HasData(fakeAddresses);
            #endregion

            #region// Seeding Topics table

            var topicFaker = new Faker<Topic>()
                .RuleFor(u => u.Name, f => f.Random.Words(3).ToString())
                .RuleFor(u => u.MaxMarks, f => f.Random.Number(20, 40));

            var fakeTopics = topicFaker.Generate(10);
            for (int i = 0; i < fakeTopics.Count; i++)
            {
                fakeTopics[i].Id = i + 1;

            }
            modelBuilder.Entity<Topic>().HasData(fakeTopics);
            #endregion

            #region// Seeding Questions table
            var questions = new string[] {
                "<h1>this is question</h1>",
                "<h2>this is question</h2>",
                "<h3>this is question</h3>",
                "<h1>this is question</h1>" };

            var questionFaker = new Faker<Question>()
                .RuleFor(c => c.DifficultyLevelId, f => f.Random.Number(1, difficultyLevelEntries.Count))
                .RuleFor(c => c.TopicId, f => f.Random.Number(1, fakeTopics.Count))
                .RuleFor(c => c.Text, f => f.PickRandom(questions));

            var fakeQuestions = questionFaker.Generate(10);

            for (int i = 0; i < fakeQuestions.Count; i++)
            {
                fakeQuestions[i].Id = i + 1;
            }
            modelBuilder.Entity<Question>().HasData(fakeQuestions);
            #endregion

            #region// Seeding Options table
            var options = new string[] {
                "<h1>this is an option</h1>",
                "<h2>this is an option</h2>",
                "<h3>this is an option</h3>",
                "<h1>this is an option</h1>" };

            var optionFaker = new Faker<Option>()
                .RuleFor(c => c.Text, f => f.PickRandom(options))
                .RuleFor(c => c.QuestionId, f => f.Random.Number(1, fakeQuestions.Count));


            var fakeOptions = optionFaker.Generate(10);
            for (int i = 0; i < fakeQuestions.Count; i++)
            {
                fakeOptions[i].Id = i + 1;
                fakeOptions[i].Correct = false;
            }
            modelBuilder.Entity<Option>().HasData(fakeOptions);
            #endregion

            #region // Seeding Certificates table
            var certFaker = new Faker<Certificate>()
                .RuleFor(c => c.Title, f => f.Random.Words(3))
                .RuleFor(c => c.Description, f => f.Random.Words(10))
                .RuleFor(c => c.Category, f => f.Random.Words(1))
                .RuleFor(c => c.Active, f => f.Random.Bool());
               


            var fakeCerts = certFaker.Generate(10);
            for (int i = 0; i < fakeCerts.Count; i++)
            {
                fakeCerts[i].Id = i + 1;
                fakeCerts[i].PassingMark = 0;
                //var faketopicsforCert = new List<Topic>();
                //for (int j=0; j<3; j++)
                //{
                //    faketopicsforCert.Add(fakeTopics[fakeNum10]);
                //}
                //fakeCerts[i].Topics = faketopicsforCert;
            }
            modelBuilder.Entity<Certificate>().HasData(fakeCerts);

            #endregion

            #region // Seeding CertificateTopic join table
            //var fakeCertificateTopics = new List<CertificateTopic>();
            //for (int i = 0; i < 30; i++)
            //{
            //    //var valuesleft = fakeTopics;
            //    for (int j = 0; j < 3; j++)
            //    {
            //        fakeCertificateTopics.Add(new CertificateTopic()
            //        {
            //            //TopicId = j,
            //        //    fakeCertificateTopics[i].CertificateId = faker.PickRandom<int>(fakeCerts[fakeNum10 - 1].Id);
            //        //fakeCertificateTopics[i].TopicId = faker.PickRandom<int>(fakeTopics[fakeNum10 - 1].Id);
            //            //CertificateId = i
            //        });

            //    }
            //}
            modelBuilder.Entity<CertificateTopic>().HasData(
                new CertificateTopic { TopicId = 1, CertificateId = 1 },
                new CertificateTopic { TopicId = 2, CertificateId = 1 },
                new CertificateTopic { TopicId = 3, CertificateId = 1 },
                new CertificateTopic { TopicId = 4, CertificateId = 2 },
                new CertificateTopic { TopicId = 5, CertificateId = 2 },
                new CertificateTopic { TopicId = 6, CertificateId = 2 },
                new CertificateTopic { TopicId = 4, CertificateId = 3 },
                new CertificateTopic { TopicId = 2, CertificateId = 3 },
                new CertificateTopic { TopicId = 1, CertificateId = 3 }
                );
            #endregion

            #region // Seeding Exams table

            modelBuilder.Entity<Exam>().HasData(
                new Exam {Id = 1, CertificateId = 1 },
                new Exam {Id = 2, CertificateId = 1 },
                new Exam {Id = 3, CertificateId = 2 },
                new Exam {Id = 4, CertificateId = 3 },
                new Exam {Id = 5, CertificateId = 3 },
                new Exam {Id = 6, CertificateId = 3 },
                new Exam {Id = 7, CertificateId = 4 }
                );

            #endregion

            #region // Seeding ExamQuestion table

            modelBuilder.Entity<ExamQuestion>().HasData(
                new ExamQuestion { ExamsId = 1, QuestionId = 1 },
                new ExamQuestion { ExamsId = 1, QuestionId = 2 },
                new ExamQuestion { ExamsId = 1, QuestionId = 3 },
                new ExamQuestion { ExamsId = 1, QuestionId = 4 },
                new ExamQuestion { ExamsId = 1, QuestionId = 5 },
                new ExamQuestion { ExamsId = 2, QuestionId = 6 },
                new ExamQuestion { ExamsId = 2, QuestionId = 7 },
                new ExamQuestion { ExamsId = 2, QuestionId = 8 },
                new ExamQuestion { ExamsId = 2, QuestionId = 9 }
                );

            #endregion

            #region // Seeding CAndiadateExam table


            #endregion
        }
    }
    }
