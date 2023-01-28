using Assignment4Final.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO;
using ModelLibrary.Models.DTO.Candidates;
using ModelLibrary.Models.DTO.Questions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _candidateService;

        public CandidateController(CandidateService candidateService)
        {            
            _candidateService = candidateService;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            return Ok(await _candidateService.GetAllAsync());
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(string id)
        {
            return Ok(await _candidateService.GetCandidateById(id));
        }

        // POST api/<CandidateController>
        [HttpPost]
        public void CreateCandidate([FromBody] string value)
        {
        }

        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public void UpdateCandidate(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(string id)
        {
            var response = new BaseResponse<CandidatesDto>
            {
                RequestId = Guid.NewGuid().ToString()
            };

            var candidateDeleted = await _candidateService.DeleteCandidate(id);

            if (candidateDeleted == null)
            {
                response.Success = false;
                response.Message = $"Error in deleting Question with id: {id}";
                return NotFound(response);
            }

            response.Success = true;
            response.Data = candidateDeleted;

            return Ok(response);
            
        }
    }
}
