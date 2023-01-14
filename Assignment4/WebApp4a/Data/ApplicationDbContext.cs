using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;
using System.Reflection.Emit;
using WebApp4a.Data.ModelBuilderExtensions;

namespace WebApp4a.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<PhotoIdType> PhotoIdTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<CandidateExam> CandidateExams { get; set; }
        public virtual DbSet<CandidateExamAnswers> CandidateExamAnswers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();


            #region // NOTE(akotro): Configures AppUserId to be Candidate's PK + FK to AppUser
            builder
                .Entity<AppUser>()
                .HasOne(a => a.Candidate)
                .WithOne(c => c.AppUser)
                .HasForeignKey<Candidate>(c => c.AppUserId)
                .IsRequired(false);
            builder.Entity<Candidate>().HasKey(c => c.AppUserId);
            #endregion

            //builder.Entity<Gender>().Property(c=>c.Id).ValueGeneratedOnAdd();
        }
        //private void SeedUsers(ModelBuilder builder)
        //{
        //    AppUser user = new AppUser()
        //    {
        //        Id = "b74ddd14-6340-4840-95c2-db12554843e5",
        //        UserName = "Admin",
        //        Email = "admin@gmail.com",
        //        LockoutEnabled = false,
        //        PhoneNumber = "1234567890"
        //    };

        //    PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
        //    passwordHasher.HashPassword(user, "Admin*123");

        //    builder.Entity<AppUser>().HasData(user);
        //}

        //private void SeedRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityRole>().HasData(
        //    new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", 
        //        Name = "Admin", 
        //        ConcurrencyStamp = "1", 
        //        NormalizedName = "Admin" },
        //    new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", 
        //        Name = "HR", 
        //        ConcurrencyStamp = "2", 
        //        NormalizedName = "Human Resource" }
        //    );
        //}

        //private void SeedUserRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityUserRole<string>>().HasData(
        //    new IdentityUserRole<string>() { 
        //        RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", 
        //        UserId = "b74ddd14-6340-4840-95c2-db12554843e5" 
        //    }
        //    );
        //}
    }
}
