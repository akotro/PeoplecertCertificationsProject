using Assignment4Final.Data;
using Assignment4Final.Data.Repositories;
using Assignment4Final.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ExamService _examService;

        public ExamsController(ExamService examService)
        {
            _examService= examService;
        }
        [HttpGet]  //GET: Return all the available Exams in db 
        public async Task<ActionResult<List<ExamDto>>> GetAll()
        {
            var exams = await  _examService.GetExamsAsync();
            return Ok(_examService.GetExamDtoList(exams));

        }
    }
}
