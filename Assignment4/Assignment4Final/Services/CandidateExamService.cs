using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Services
{
    public class CandidateExamService
    {
        private readonly CandidateExamRepository _candidateExamRepository;
        private readonly ExamService _examService;
        private readonly IMapper _mapper;

        public CandidateExamService(
            CandidateExamRepository candidateExamRepository,
            IMapper mapper,
            ExamService examService
        )
        {
            _candidateExamRepository = candidateExamRepository;
            _mapper = mapper;
            _examService = examService;
        }

        public async Task<Candidate?> GetCandidateByUserId(string userId)
        {
            return await _candidateExamRepository.GetCandidateByUserId(userId);
        }

        public async Task<CandidateExam> GetCandidateExamByExam(Exam exam, string userId)
        {
            var candidate = await GetCandidateByUserId(userId);
            var examEntity = await _examService.GetExamAsync(exam.Id);
            var candidateExam = new CandidateExam()
            {
                Candidate = candidate,
                Exam = examEntity,
                Voucher = Guid.NewGuid().ToString()
            };
            return candidateExam;
        }

        public void AddCandidateExam(ref CandidateExam candidateExam)
        {
            _candidateExamRepository.Add(ref candidateExam);
        }

        public CandidateExamDto GetCandidateExamDtoFromCandidateExam(CandidateExam candidateExam)
        {
            _candidateExamRepository.LoadCertificateOfCandidateExamEntity(ref candidateExam);
            return _mapper.Map<CandidateExamDto>(candidateExam);
        }


        public async Task<List<CandidateExam>> GetAllCandidateExamsOfCandidateAsync(Candidate candidate)
        {
            return await _candidateExamRepository.GetAllCandidateExamsOfCandidateAsync(candidate);
        }

        public async Task<List<CandidateExam>> GetTakenCandidateExamsOfCandidateAsync(Candidate candidate)
        {
            return await _candidateExamRepository.GetTakenCandidateExamsOfCandidateAsync(candidate);
        }

        public List<CandidateExamDto> GetListOfCandidateExamDtosFromListOfCandidateExam(List<CandidateExam> candidateExams)
        {
            return _mapper.Map<List<CandidateExamDto>>(candidateExams);
        }
    }
}
