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
            if(candidateExam.Exam != null)
            {

            _context.Entry(candidateExam.Exam).Reference("Certificate").Load();
            }

        }


        public async Task<List<CandidateExam>> GetAllCandidateExamsOfCandidateAsync(Candidate candidate)
        {
            return await _context.CandidateExams.Where(candexam => candexam.Candidate == candidate).ToListAsync();
        }
        
        public async Task<List<CandidateExam>> GetTakenCandidateExamsOfCandidateAsync(Candidate candidate)
        {
            return await _context.CandidateExams.Include(candExam => candExam.Candidate).Where(candExam => (candExam.Candidate == candidate && candExam.Result == null)).ToListAsync();
        }



    }
}
