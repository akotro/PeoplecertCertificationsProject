using ModelLibrary.Models.Exams;

namespace Assignment4Final.Data.Repositories;

public interface IMarkersRepository
{
    Task<List<Marker>> GetAllAsync();
    Task<Marker?> GetAsync(string id);
    Task<Marker?> AddAsync(Marker marker);
    Task<Marker?> UpdateAsync(string id, Marker marker);
    Task<Marker?> DeleteAsync(string id);
    Task<CandidateExam?> MarkCandidateExamAsync(int candExamId, CandidateExam candExam);
    bool EntityExists(string id);
}