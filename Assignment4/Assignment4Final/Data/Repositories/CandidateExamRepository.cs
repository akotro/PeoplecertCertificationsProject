using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Data.Repositories
{
    public class CandidateExamRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate?> GetCandidateByUserId(string userId)
        {
            return await  _context.Candidates.Where(cand => cand.AppUser.Id == userId)
                .FirstOrDefaultAsync();
        }

        public  void Add( ref CandidateExam candidateExam)
        {
              _context.CandidateExams.Add(candidateExam);
              _context.SaveChanges();
        }

        public void LoadCertificateOfCandidateExamEntity(ref CandidateExam candidateExam)
        {
            _context.Entry(candidateExam).Reference("Exam").Load();
            _context.Entry(candidateExam.Exam).Reference("Certificate").Load();

        }



    }
}
