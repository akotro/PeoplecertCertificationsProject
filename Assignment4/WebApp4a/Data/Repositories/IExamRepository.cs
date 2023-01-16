using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;

namespace WebApp4a.Data.Repositories
{
    public interface IExamRepository
    {
        public Task<IEnumerable<Question>> GetAllQuestionsAsync(CandidateExam candidateExam);
        public Task<CandidateExam> AddCandidateExam(IEnumerable<bool> dropDownOptions, CandidateExam candidateExam);
    }
}
