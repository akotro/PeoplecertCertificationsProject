//////using Assignment4Final.Data.Repositories;
using Assignment4Final.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.DTO.Certificates;
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



        [HttpPost("CreateCandExam")] //this API is so a candidate can buy from the available certificates
        public async Task<ActionResult<CandidateExamDto>> Get([FromBody] int certId)
        {
            var userId = _userManager.GetUserId(User);
            //var candExamDto = await  _candExamService.GetCandidateExamByCertificateAsync(certId,userId);
            var candExamDto = await  _candExamService.GetCandidateExamByCertificateAsync(certId, "0aba6917-8f7c-4f00-a200-58e139fe616e");
            return Ok(candExamDto);
        }




        [HttpGet] // All the candidateExams the candidate has bought . both taken and not taken 
        public async Task<ActionResult<List<CandidateExamDto>>> GetAll()
        {

            //var candidate = await _candExamService.GetCandidateByUserIdAsync(_userManager.GetUserId(User));
            var candidate = await _candExamService.GetCandidateByUserIdAsync("0aba6917-8f7c-4f00-a200-58e139fe616e");
            if (candidate == null)
            {
                return NotFound(new { description = "Candidate with this userId not found " });
            }
            var candidateExamsList = await _candExamService.GetAllCandidateExamsOfCandidateAsync(candidate);
            return Ok(await Task.Run(() => _candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(candidateExamsList)));

        }


        [HttpGet("notTaken")] // all the CandidateExams the candidate has bought but not yet taken (picked by cendidateExam.Result == null)
        public async Task<ActionResult<List<CandidateExamDto>>> GetAllNotTaken() //Not Debuged all the candidate exams in Seed are Taken . Should i checke if taken by ExamDate?
        {
            
            //var candidate = await _candExamService.GetCandidateByUserIdAsync(_userManager.GetUserId(User));
            var candidate = await _candExamService.GetCandidateByUserIdAsync("0aba6917-8f7c-4f00-a200-58e139fe616e");
            if(candidate == null)
            {
                return NotFound(new {description ="Candidate with this userId not found "});
            }
            var candidatesTakenExams = await _candExamService.GetTakenCandidateExamsOfCandidateAsync(candidate);
            return Ok(_candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(candidatesTakenExams));

        }


        [HttpPut("StartExam")] // this Api is for getting a CandidateExamDto full with the CandidatesAnswers and ExamsQuestions 
        public async Task<ActionResult<CandidateExamDto>> GetCandExmWithAnswers([FromBody] int candExamId)
        {
            var candExamDto = await _candExamService.UpdateWithAnswersCandidateExamDtoAsync(candExamId);

            return Ok(candExamDto);  

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
