using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;
using System.Reflection.Emit;
using ModelLibrary.Models.Questions;
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

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Option> Options { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<CandidateExam> CandidateExams { get; set; }
        public virtual DbSet<CandidateExamAnswers> CandidateExamAnswers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Join tables configuration
            builder
                .Entity<CandidateExam>()
                .HasOne(c => c.Candidate)
                .WithMany(c => c.CandidateExams)
                .HasForeignKey(t => t.CandidateId);
            builder
                .Entity<CandidateExam>()
                .HasOne(c => c.Exam)
                .WithMany(c => c.CandidateExams)
                .HasForeignKey(t => t.ExamId);

            builder.Seed(this);

            #region // NOTE(akotro): Configures AppUserId to be Candidate's PK + FK to AppUser

            builder
                .Entity<AppUser>()
                .HasOne(a => a.Candidate)
                .WithOne(c => c.AppUser)
                .HasForeignKey<Candidate>(c => c.AppUserId)
                .IsRequired(false);
            builder.Entity<Candidate>().HasKey(c => c.AppUserId);

            #endregion
        }
    }
}
