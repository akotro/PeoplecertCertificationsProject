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
        //public virtual DbSet<CertificateTopic> CertificateTopic { get; set; }
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
            // Join tables configuration
            builder.Entity<CertificateTopic>()
                .HasKey(t => new { t.CertificateId, t.TopicId });
            builder.Entity<CertificateTopic>()
                .HasOne(c => c.Certificate)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CertificateId);
            builder.Entity<CertificateTopic>()
                .HasOne(c => c.Topic)
                .WithMany(c => c.Certificates)
                .HasForeignKey(t => t.TopicId);

            builder.Entity<ExamQuestion>()
              .HasKey(t => new { t.ExamsId, t.QuestionId });
            builder.Entity<ExamQuestion>()
                .HasOne(c => c.Exam)
                .WithMany(c => c.Questions)
                .HasForeignKey(t => t.ExamsId);
            builder.Entity<ExamQuestion>()
                .HasOne(c => c.Question)
                .WithMany(c => c.Exams)
                .HasForeignKey(t => t.QuestionId);



            //builder.Entity<Certificate>()
            //    .HasMany(c => c.Topics)
            //    .WithMany(c => c.Certificates)
            //    .UsingEntity<CertificateTopic>(ct =>
            //    {
            //        ct.ToTable("CertificateTopic");
            //        ct.HasOne(x => x.Certificate).WithMany().HasForeignKey("CertificateId");
            //        ct.HasOne(x => x.Topic).WithMany().HasForeignKey("TopicId");
            //    });

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

        }
      
    }
}
