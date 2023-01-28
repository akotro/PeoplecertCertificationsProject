using Assignment4Final.Data.Repositories;
using AutoMapper;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.DTO.Candidates;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.Questions;

namespace Assignment4Final.Services
{
    public class CandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidatesDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CandidatesDto>>(await _candidateRepository.GetAllAsync());
        }

        public async Task<CandidatesDto> GetCandidateById(string appUserId)
        {
            return _mapper.Map<CandidatesDto>(await _candidateRepository.GetCandidate(appUserId));
        }

        public async Task<CandidatesDto?> DeleteCandidate(string appUserId)
        {
            return _mapper.Map<CandidatesDto>(await _candidateRepository.DeleteCandidate(appUserId));             
        }
    }
}
