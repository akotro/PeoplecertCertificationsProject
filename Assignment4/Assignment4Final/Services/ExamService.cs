using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Services
{
    public class ExamService
    {
        private readonly ExamRepository _repository;
        private readonly IMapper _mappers;

        public ExamService(ExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mappers = mapper;
        }
        
        public async Task<List<Exam>> GetExamsAsync()
        {
            return await _repository.GetAllExamsAsync();
        }


        public List<ExamDto> GetExamDtoList(List<Exam> exams)
        {
            return _mappers.Map<List<ExamDto>>(exams);
        }






    }
}
