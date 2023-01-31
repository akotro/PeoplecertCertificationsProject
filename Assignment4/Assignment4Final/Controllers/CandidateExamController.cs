using Assignment4Final.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CandidateExamService _candExamService;
        private readonly ExamService _examService;
        public CandidateExamController(UserManager<AppUser> userManager, CandidateExamService candExamService, ExamService examService)
        {
            _userManager = userManager;
            _candExamService = candExamService;
            _examService = examService;
           
        }


        [HttpGet("{examDto}")] //Get : when the candidate picks an exam it makes a candidate exam for this candidate and the exam he picked
        public async Task<ActionResult<CandidateExam>> GetCandidateExamFromPickedExam(ExamDto examDto) 
        {
            var exam = _examService.GetExamFromExamDto(examDto);
            var userId = _userManager.GetUserId(User);
            var candidateExam = await _candExamService.GetCandidateExamByExam(exam,userId);
            await Task.Run(() => _candExamService.AddCandidateExam(ref candidateExam));
            var candidateExamDto = _candExamService.GetCandidateExamDtoFromCandidateExam(candidateExam);

            return Ok(candidateExamDto);
        }
    }
}
