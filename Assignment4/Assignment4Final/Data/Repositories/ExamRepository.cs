using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Data.Repositories
{
    public class ExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetAllExamsAsync(bool include = true)
        {
            if (include)
            {
                return await _context.Exams.Include(exam => exam.Certificate).ToListAsync();
            }
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam?> GetExamAsync(int id)
        {
            return await _context.Exams
                .Include(e => e.Certificate)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
