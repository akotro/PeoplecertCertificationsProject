using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Questions;
using WebApp4a.Services;

namespace WebApp4a.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QuestionsService _questionService;

        public QuestionsController(QuestionsService questionsService)
        {
            _questionService = questionsService;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return _questionService.QuestionsDbSetExists()
                ? View(await _questionService.GetAllAsync())
                : Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            var question = await _questionService.GetAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            var questionDto = _questionService.CreateDto();

            ViewBag.Topics = _questionService.GetTopicsSelectList();
            ViewBag.DifficultyLevels = _questionService.GetDifficultyLevelsSelectList();

            return View(questionDto);
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.AddAsync(questionDto);

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var questionDto = await _questionService.CreateDto(id);

            ViewBag.Topics = _questionService.GetTopicsSelectList();
            ViewBag.DifficultyLevels = _questionService.GetDifficultyLevelsSelectList();

            return View(questionDto);
        }

        // POST: Questions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.UpdateAsync(id, questionDto);

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_questionService.QuestionsDbSetExists())
            {
                return NotFound();
            }

            var question = await _questionService.GetAsync(id, false);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_questionService.QuestionsDbSetExists())
            {
                return Problem("Entity set 'ApplicationDbContext.Questions' is null.");
            }

            await _questionService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
