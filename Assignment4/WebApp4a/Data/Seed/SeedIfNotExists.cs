using Bogus;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using WebApp4a.GiannisServices;


namespace WebApp4a.Data.Seed
{
    public static class SeedIfNotExists
    {
        public static void SeedIfEmpty(WebApplication? app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    DbSeed.Initialise(context);
                    DbSeed.AddCalculated(context);
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

        }
    }
}
