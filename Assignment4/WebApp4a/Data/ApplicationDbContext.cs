using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidate;

namespace WebApp4a.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<PhotoIdType> PhotoIdTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
