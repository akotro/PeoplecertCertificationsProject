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
        CertificatesRepository _certificatesRepository;

        public CandidateExamService(
            CandidateExamRepository candidateExamRepository,
            IMapper mapper,
            ExamService examService,
            CertificatesRepository certificatesRepository

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




        public async Task<CandidateExamDto?> GetCandidateExamByCertificateAsync(CertificateDto certificateDto,string userId)
        {
            var certificate = await _certificatesRepository.GetAsync(certificateDto.Id); // used this so the entity is loaded

            var exam = GetRandomExam(certificate.Exams.ToList());

            var candExam = new CandidateExam { Candidate = await _candidateExamRepository.GetCandidateByUserIdAsync(userId), Exam = exam };

            _candidateExamRepository.Add(ref candExam);

            return _mapper.Map<CandidateExamDto>(candExam);

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

        public async Task<CandidateExam?> GetCandidateExamByIdsync(int id)
        {
            return await _candidateExamRepository.GetCandidateExamByIdAsync(id);
        }


        public async Task<CandidateExamDto?> UpdateWithAnswersCandidateExamDtoAsync(CandidateExamDto candidateExamDto)
        {
            var candidateExam = await _candidateExamRepository.GetCandidateExamByIdAsync(candidateExamDto.Id);
            if(candidateExam != null)
            {
                CreateCandidateExamAnswers(candidateExam);
                return _mapper.Map<CandidateExamDto>(candidateExam);
            }
            return null;
           
        }



        public CandidateExam? CreateCandidateExamAnswers(CandidateExam candidateExam)
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
                Task.Run(() => _candidateExamRepository.Add(ref candidateExam));
                return candidateExam;
            }
            return null;
        }





        
    }
}
