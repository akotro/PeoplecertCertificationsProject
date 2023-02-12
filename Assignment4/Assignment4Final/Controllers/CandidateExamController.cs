using Assignment4Final.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.CandidateExam;

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CandidateExamService _candExamService;
        private readonly ExamService _examService;

        public CandidateExamController(
            UserManager<AppUser> userManager,
            CandidateExamService candExamService,
            ExamService examService
        )
        {
            _userManager = userManager;
            _candExamService = candExamService;
            _examService = examService;
        }

        ////Post : when the candidate picks an exam it makes a candidate exam for this candidate and the exam he picked
        //[HttpPost]
        //public async Task<ActionResult<CandidateExam>> GetCandidateExamFromPickedExam(
        //    [FromBody] ExamDto examDto
        //)
        //{
        //    var exam = _examService.GetExamFromExamDto(examDto);

        //    var userId = _userManager.GetUserId(User);
        //    var candidateExam = await _candExamService.GetCandidateExamByExam(exam, userId);
        //    await Task.Run(() => _candExamService.AddCandidateExam(ref candidateExam));
        //    var candidateExamDto = _candExamService.GetCandidateExamDtoFromCandidateExam(
        //        candidateExam
        //    );

        //    return Ok(candidateExamDto);
        //}

        [HttpPost("CreateCandExam/{certId}")] //this API is so a candidate can buy from the available certificates
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Policy = "IsAny"
        )]
        public async Task<ActionResult<CandidateExamDto>> Get(int certId)
        {
            var userId = _userManager.GetUserId(User);
            var candExamDto = await _candExamService.GetCandidateExamByCertificateAsync(
                certId,
                userId
            );
            // var candExamDto = await _candExamService.GetCandidateExamByCertificateAsync(
            //     certId,
            //     "02458d8c-aba2-4b3d-86de-8f8457570c60"
            // );
            return Ok(candExamDto);
        }

        [HttpGet] // All the candidateExams the candidate has bought . both taken and not taken
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Policy = "IsAdminOrCandidate"
        )]
        public async Task<ActionResult<List<CandidateExamDto>>> GetAll()
        {
            var candidate = await _candExamService.GetCandidateByUserIdAsync(
                _userManager.GetUserId(User)
            );
            //var candidate = await _candExamService.GetCandidateByUserIdAsync("02458d8c-aba2-4b3d-86de-8f8457570c60");
            if (candidate == null)
            {
                return NotFound(new { description = "Candidate with this userId not found " });
            }

            var candidateExamsList = await _candExamService.GetAllCandidateExamsOfCandidateAsync(
                candidate
            );
            return Ok(
                await Task.Run(
                    () =>
                        _candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(
                            candidateExamsList
                        )
                )
            );
        }

        [HttpGet("notTaken")] // all the CandidateExams the candidate has bought but not yet taken (picked by cendidateExam.Result == null)
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Policy = "IsAdminOrCandidate"
        )]
        public async Task<ActionResult<List<CandidateExamDto>>> GetAllNotTaken() //Not Debuged all the candidate exams in Seed are Taken . Should i checke if taken by ExamDate?
        {
            var userManager = _userManager.GetUserId(User);
            var candidate = await _candExamService.GetCandidateByUserIdAsync(
                _userManager.GetUserId(User)
            );
            //var candidate = await _candExamService.GetCandidateByUserIdAsync("02458d8c-aba2-4b3d-86de-8f8457570c60");
            if (candidate == null)
            {
                return NotFound(new { description = "Candidate with this userId not found " });
            }

            var candidatesTakenExams =
                await _candExamService.GetNotTakenCandidateExamsOfCandidateAsync(candidate);
            return Ok(
                _candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(
                    candidatesTakenExams
                )
            );
        }

        [HttpPut("StartExam/{candExamId}")] // this Api is for getting a CandidateExamDto full with the CandidatesAnswers and ExamsQuestions when an Exam is starting
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Policy = "IsAdminOrCandidate"
        )]
        public async Task<ActionResult<CandidateExamDto>> GetCandExmWithAnswers(int candExamId)
        {
            var candidateExam = await _candExamService.GetCandidateExamByIdAsync(candExamId);

            if (
                candidateExam == null
                || candidateExam.CandidateExamAnswers == null
                || candidateExam.Result != null
            )
            {
                return NotFound(new { message = "CandidateExam Not Found Or arleady taken" });
            }

            if (candidateExam.CandidateExamAnswers.Count() > 0)
            {
                return _candExamService.GetCandidateExamDto(candidateExam);
            }

            var candExamDto = await _candExamService.UpdateWithAnswersCandidateExamDtoAsync(
                candidateExam
            );
            return Ok(candExamDto);
        }

        [HttpPut("EndExam/{candExamId}")] //Api to end the exam procces
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Policy = "IsAdminOrCandidate"
        )]
        public async Task<ActionResult<CandidateExamDto>> GetCandidateExamWithResults(
            int candExamId
        )
        {
            var candidateExam = await _candExamService.GetCandidateExamByIdAsync(candExamId);
            var candidateExamUpdated = await _candExamService.UpdatdeWithResults(candidateExam);
            return Ok(_candExamService.GetCandidateExamDto(candidateExamUpdated));
        }

        //[HttpPost("QuestionsAndAnswers")]
        //public async Task<ActionResult<CandidateExamQuestionsAndAnswersDto>> GetQuestionsAndAnswers([FromBody] int id)
        //{

        //    var candExam = await _candExamService.GetCandidateExamByIdsync(1002);
        //    if(candExam == null)
        //    {
        //        return NotFound("candidateExam with this id not found");
        //    }
        //    return _candExamService.GetQuestionsAndAnswersDto(candExam);


        //}
    }
}
