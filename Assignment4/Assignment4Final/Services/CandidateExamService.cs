using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.DTO.Certificates;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Services
{
    public class CandidateExamService
    {
        private readonly CandidateExamRepository _candidateExamRepository;
        private readonly ExamService _examService;
        private readonly IMapper _mapper;
        private readonly ICertificatesRepository _certificatesRepository;

        public CandidateExamService(
            CandidateExamRepository candidateExamRepository,
            IMapper mapper,
            ExamService examService,
            ICertificatesRepository certificatesRepository

        )
        {
            _candidateExamRepository = candidateExamRepository;
            _mapper = mapper;
            _examService = examService;
            _certificatesRepository = certificatesRepository;
        }

        public async Task<Candidate?> GetCandidateByUserIdAsync(string userId)
        {
            return await _candidateExamRepository.GetCandidateByUserIdAsync(userId);
        }

        //public async Task<CandidateExam> GetCandidateExamByExam(Exam exam, string userId)  //NOT nedded maybe
        //{
        //    var candidate = await GetCandidateByUserIdAsync(userId);
        //    var examEntity = await _examService.GetExamAsync(exam.Id);
        //    var candidateExam = new CandidateExam()
        //    {
        //        Candidate = candidate,
        //        Exam = examEntity,
        //        Voucher = Guid.NewGuid().ToString()
        //    };
        //    return candidateExam;
        //}




        public async Task<CandidateExamDto?> GetCandidateExamByCertificateAsync(int certId,string userId)
        {
            var certificate = await _certificatesRepository.GetAsync(certId); // used this so the entity is loaded

            var exam = GetRandomExam(certificate.Exams.ToList());

            var candExam = new CandidateExam { Candidate = await _candidateExamRepository.GetCandidateByUserIdAsync(userId), Exam = exam };

            var candExamUpdated = await _candidateExamRepository.Add(candExam);

            return _mapper.Map<CandidateExamDto>(candExamUpdated);

        }


        public Exam GetRandomExam(List<Exam> exams)
        {
            Random random = new Random();
            int count = exams.Count();
            var exam = exams[random.Next(0, count)];
            return exam;

        }


        public void AddCandidateExam(ref CandidateExam candidateExam)
        {
            _candidateExamRepository.Add( candidateExam);
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

        public async Task<CandidateExam?> GetCandidateExamByIdsync(int id)
        {
            return await _candidateExamRepository.GetCandidateExamByIdAsync(id);
        }


        public async Task<CandidateExamDto?> UpdateWithAnswersCandidateExamDtoAsync(int candExamId)
        {
            var candidateExam = await _candidateExamRepository.GetCandidateExamByIdAsync(candExamId);
            if(candidateExam != null)
            {
                var candidateExamUpdated = await CreateCandidateExamAnswersAsync(candidateExam);
                var mapped = _mapper.Map<CandidateExamDto>(candidateExamUpdated);
                return mapped;
            }
            return null;
           
        }



        public async Task<CandidateExam?> CreateCandidateExamAnswersAsync(CandidateExam candidateExam)
        {
            if(candidateExam.Exam != null && candidateExam.Exam.Questions!= null && candidateExam.CandidateExamAnswers != null)
            {
                var questions = candidateExam.Exam.Questions.ToList();

                questions.ForEach(question => candidateExam.CandidateExamAnswers
                .Add(new CandidateExamAnswers()
                {
                    QuestionText = question.Text,
                    CorrectOption = question.Options != null ?
                    question.Options.Where(opt => opt.Correct).FirstOrDefault().Text : null,

                }));
                var candidateExamUpdated = await Task.Run(() => _candidateExamRepository.Add(candidateExam));
                return candidateExamUpdated;
            }
            return null;
        }





        
    }
}
