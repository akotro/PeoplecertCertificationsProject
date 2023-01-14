using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;

namespace WebApp4a.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
            // NOTE(akotro): Configures AppUserId to be Candidate's PK + FK to AppUser
            builder
                .Entity<AppUser>()
                .HasOne(a => a.Candidate)
                .WithOne(c => c.AppUser)
                .HasForeignKey<Candidate>(c => c.AppUserId)
                .IsRequired(false);
            builder.Entity<Candidate>().HasKey(c => c.AppUserId);
        }
    }
}
