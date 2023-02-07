using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Services;

public class MarkersService
{
    private readonly IGenericRepository<Marker> _repository;
    private readonly IMapper _mapper;

    public MarkersService(IGenericRepository<Marker> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<MarkerDto>> GetAllAsync()
    {
        var markers = await _repository.GetAllAsync();
        return _mapper.Map<List<MarkerDto>>(markers);
    }

    public async Task<MarkerDto?> GetAsync(string id)
    {
        var marker = await _repository.GetAsync(id);

        if (marker == null)
        {
            return null;
        }

        var markerDto = _mapper.Map<MarkerDto>(marker);

        // NOTE:(akotro) Fill IsCorrectModerated with values from IsCorrect
        if (markerDto.CandidateExams?.Any() == true)
        {
            foreach (var candExam in markerDto.CandidateExams)
            {
                if (candExam.CandidateExamAnswers?.Any(a => a.IsCorrectModerated == null) == true)
                {
                    foreach (
                        var answer in candExam.CandidateExamAnswers.Where(
                            a => a.IsCorrectModerated == null
                        )
                    )
                    {
                        answer.IsCorrectModerated = answer.IsCorrect;
                    }
                }
            }
        }

        return markerDto;
    }

    public async Task<MarkerDto?> AddAsync(MarkerDto markerDto)
    {
        var marker = _mapper.Map<Marker>(markerDto);
        var addedMarker = await _repository.AddAsync(marker);
        return addedMarker == null ? null : _mapper.Map<MarkerDto>(addedMarker);
    }

    public async Task<MarkerDto?> UpdateAsync(string id, MarkerDto markerDto)
    {
        // NOTE:(akotro) Calculate new score from moderation only for moderated exams
        if (markerDto.CandidateExams?.Any() == true)
        {
            foreach (var candExam in markerDto.CandidateExams.Where(ce => ce.IsModerated == true))
            {
                var score = candExam.CandidateExamAnswers?.Count(
                    answer => (bool)answer.IsCorrectModerated
                );
                candExam.CandidateScore = score;
                candExam.PercentScore = (score / candExam.MaxScore) * 100;
                candExam.Result =
                    candExam.CandidateScore >= candExam.Exam?.Certificate?.PassingMark
                        ? true
                        : false;
                candExam.MarkingDate = DateTime.Now; // NOTE:(akotro) Should this be in UTC?
            }
        }

        var marker = _mapper.Map<Marker>(markerDto);

        var updatedMarker = await _repository.UpdateAsync(id, marker);
        return updatedMarker == null ? null : _mapper.Map<MarkerDto>(updatedMarker);
    }

    public async Task<MarkerDto?> DeleteAsync(string id)
    {
        var deletedMarker = await _repository.DeleteAsync(id);
        return deletedMarker == null ? null : _mapper.Map<MarkerDto>(deletedMarker);
    }

    public bool MarkerExists(string id)
    {
        return _repository.EntityExists(id);
    }
}
