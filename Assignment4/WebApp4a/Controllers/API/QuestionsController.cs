using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Questions;
using WebApp4a.Services;

namespace WebApp4a.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionsService _questionService;

        public QuestionsController(QuestionsService questionsService)
        {
            _questionService = questionsService;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return Problem("Entity set 'ApplicationDbContext.Questions' is null.");
            }

            return Ok(await _questionService.GetAllAsync());
        }

        // GET: api/questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            var question = await _questionService.GetAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // POST: api/questions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionDto questionDto)
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _questionService.AddAsync(questionDto);
                return CreatedAtAction(nameof(Get), new { id = questionDto.Id },
                    questionDto);
            }

            return BadRequest();
        }

        // PUT: api/questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] QuestionDto questionDto)
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _questionService.UpdateAsync(id, questionDto);
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE: api/questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            await _questionService.Delete(id);
            return NoContent();
        }
    }
}
