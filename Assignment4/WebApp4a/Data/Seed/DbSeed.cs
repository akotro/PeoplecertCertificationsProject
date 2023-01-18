using Bogus;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace WebApp4a.Data.Seed
{
    public static class DbSeed
    {
        public static void Initialise(ApplicationDbContext db)
        {
            Randomizer.Seed = new Random(8675309);
            var faker = new Faker();

            if (db.Exams.Include(c => c.Questions).Any())
            {
                foreach (var item in db.Exams.ToList())
                {
                    item.Questions = new List<Question>() {
                                faker.PickRandom(db.Questions.ToList()),
                                faker.PickRandom(db.Questions.ToList()),
                                faker.PickRandom(db.Questions.ToList()),
                                faker.PickRandom(db.Questions.ToList())
                            };
                    db.SaveChanges();

                };

            };

            if (db.Certificates.Include(c => c.Topics).Any())
            {
                foreach (var item in db.Certificates.ToList())
                {
                    item.Topics = new List<Topic>() {    faker.PickRandom(db.Topics.ToList()),
                                faker.PickRandom(db.Topics.ToList()),
                                faker.PickRandom(db.Topics.ToList()),
                                faker.PickRandom(db.Topics.ToList())};
                    db.SaveChanges();
                }

            };
        }
        public static void AddCalculated(ApplicationDbContext db)
        {

            //if (db.Certificates.Where(c => c.PassingMark == 0))
            var certs = db.Certificates;
            for (int j = 1; j < certs.ToList().Count() + 1; j++)
            {
                var maxMarksList = certs.Where(i => i.Id == j)
                    .Include(x => x.Topics)
                    .ToList();  //.ThenInclude(c => c.)
                foreach (var item in maxMarksList)
                {
                    item.MaxMark = 0;
                    foreach (var topic in item.Topics)
                    {
                        item.MaxMark = item.MaxMark + topic.MaxMarks;
                    }
                    //db.SaveChanges();
                }
            }

            for (int j = 1; j < certs.ToList().Count() + 1; j++)
            {
                var cert = certs.Where(i => i.Id == j).FirstOrDefault();
                var result = cert.MaxMark * (65 / 100.0);
                cert.PassingMark = Convert.ToInt32(result);
            };
            db.SaveChanges();

        }
    }

}
