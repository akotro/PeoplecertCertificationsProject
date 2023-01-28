using ModelLibrary.Models.Candidates;

namespace Assignment4Final.Data.Repositories
{
    public interface ICandidateRepository
    {
        public Task<IEnumerable<Candidate>> GetAllAsync();
        public Task<Candidate> GetCandidate(string appUserId);
        public Task<Candidate?> DeleteCandidate(string appUserId);
        public bool CandidatesDbSetExists();
    }
}