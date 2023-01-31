using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Services
{
    public class ExamService
    {
        private readonly ExamRepository _repository;
        private readonly IMapper _mapper;

        public ExamService(ExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<List<Exam>> GetListOfExamsAsync()
        {
            return await _repository.GetAllExamsAsync();
        }


        public List<ExamDto> GetExamDtoList(List<Exam> exams)
        {
            return _mapper.Map<List<ExamDto>>(exams);
        }

        

        public Exam GetExamFromExamDto(ExamDto examDto)
        {
            return _mapper.Map<Exam>(examDto);
        }
        public async Task<Exam?> GetExamAsync(int id)
        {
            return await _repository.GetExamAsync(id);
        }






    }
}
