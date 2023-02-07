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
        var certificates = await _repository.GetAllAsync();
        return _mapper.Map<List<MarkerDto>>(certificates);
    }

    public async Task<MarkerDto?> GetAsync(string id)
    {
        var certificate = await _repository.GetAsync(id);
        return certificate == null ? null : _mapper.Map<MarkerDto>(certificate);
    }

    public async Task<MarkerDto?> AddAsync(MarkerDto certificateDto)
    {
        var certificate = _mapper.Map<Marker>(certificateDto);
        var addedMarker = await _repository.AddAsync(certificate);
        return addedMarker == null ? null : _mapper.Map<MarkerDto>(addedMarker);
    }

    public async Task<MarkerDto?> UpdateAsync(string id, MarkerDto certificateDto)
    {
        var certificate = _mapper.Map<Marker>(certificateDto);
        var updatedMarker = await _repository.UpdateAsync(id, certificate);
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
