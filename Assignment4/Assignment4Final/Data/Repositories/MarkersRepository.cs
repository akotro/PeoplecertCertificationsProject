using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Data.Repositories;

public class MarkersRepository : IGenericRepository<Marker>
{
    private readonly ApplicationDbContext _context;

    public MarkersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Marker>> GetAllAsync()
    {
        return await _context.Markers
            .AsSplitQuery()
            .Include(m => m.AppUser)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.CandidateExamAnswers)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.Exam)
            .ThenInclude(e => e.Certificate)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.Exam)
            .ThenInclude(e => e.Questions)
            .ThenInclude(q => q.Options)
            .ToListAsync();
    }

    public async Task<Marker?> GetAsync(string id)
    {
        return await _context.Markers
            .AsSplitQuery()
            .Include(m => m.AppUser)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.CandidateExamAnswers)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.Exam)
            .ThenInclude(e => e.Certificate)
            .Include(m => m.CandidateExams)
            .ThenInclude(ce => ce.Exam)
            .ThenInclude(e => e.Questions)
            .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(q => q.AppUserId == id);
    }

    public async Task<Marker?> AddAsync(Marker marker)
    {
        await FillNavigationProperties(marker);

        var markerEntry = await _context.Markers.AddAsync(marker);
        await _context.SaveChangesAsync();

        return markerEntry.Entity;
    }

    public async Task<Marker?> UpdateAsync(string id, Marker marker)
    {
        var dbMarker = await GetAsync(id);

        if (dbMarker != null)
        {
            if (marker.CandidateExams != null)
            {
                var dbCandidateExamsToDelete = dbMarker.CandidateExams
                    .Where(c => !marker.CandidateExams.Any(ce => ce.Id == c.Id))
                    .ToList();
                foreach (var candExam in dbCandidateExamsToDelete)
                {
                    // NOTE:(akotro) Do not actually delete CandidateExam, just remove from candidate
                    // _context.CandidateExams.Remove(candExam);
                    dbMarker.CandidateExams.Remove(candExam);
                }

                if (marker.CandidateExams.Any())
                {
                    foreach (var candExam in marker.CandidateExams)
                    {
                        var dbCandidateExam = await _context.CandidateExams.FirstOrDefaultAsync(
                            ce => ce.Id == candExam.Id
                        );
                        if (dbCandidateExam != null)
                        {
                            if (dbMarker.CandidateExams.Any(ce => ce.Id == dbCandidateExam.Id))
                            {
                                // NOTE:(akotro) If marker already has this candExam, update it
                                dbCandidateExam.Result = candExam.Result;
                                dbCandidateExam.CandidateScore = candExam.CandidateScore;
                                dbCandidateExam.PercentScore = candExam.PercentScore;
                                dbCandidateExam.IsModerated = candExam.IsModerated;
                                dbCandidateExam.MarkingDate = candExam.MarkingDate;

                                if (candExam.CandidateExamAnswers?.Any() == true)
                                {
                                    foreach (var answer in candExam.CandidateExamAnswers)
                                    {
                                        var dbAnswer =
                                            await _context.CandidateExamAnswers.FirstOrDefaultAsync(
                                                a => a.Id == answer.Id
                                            );
                                        if (dbAnswer != null)
                                        {
                                            dbAnswer.IsCorrectModerated = answer.IsCorrectModerated;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // NOTE:(akotro) If marker does not already have the candExam, add it
                                dbMarker.CandidateExams.Add(dbCandidateExam);
                            }
                        }
                        // else
                        // {
                        //     // NOTE:(akotro) If the candExam does not exist, create it
                        //     dbMarker.CandidateExams.Add(
                        //         new CandidateExam
                        //         {
                        //             Name = candExam.Name,
                        //             MaxMarks = candExam.MaxMarks
                        //         }
                        //     );
                        // }
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        return dbMarker;
    }

    public async Task<Marker?> DeleteAsync(string id)
    {
        var marker = await GetAsync(id);

        if (marker != null)
        {
            var markerEntry = _context.Markers.Remove(marker);
            await _context.SaveChangesAsync();

            return markerEntry.Entity;
        }

        return null;
    }

    public bool EntityExists(string id)
    {
        return (_context.Markers?.Any(m => m.AppUserId == id)).GetValueOrDefault();
    }

    private async Task FillNavigationProperties(Marker marker)
    {
        // marker.AppUser = await _context.Users.FindAsync(marker.AppUserId);
        marker.CandidateExams = marker.CandidateExams
            ?.Select(async e => await _context.CandidateExams.FindAsync(e.Id))
            .Select(e => e.Result)
            .ToList();
    }
}
