using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Questions;
using WebApp4a.Data;

namespace WebApp4a.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private DifficultyLevel? GetDifficultyLevel(Question question)
        {
            // TODO:(akotro) This belongs to a QuestionsRepository

            // NOTE:(akotro) Using enums means that whenever a DifficultyLevel is edited or created,
            // a new row in the database is always created. Therefore, we use a switch to find the
            // difficulty level from the database and return it.

            DifficultyLevel? result = null;

            switch (question.DifficultyLevel.Difficulty)
            {
                case DifficultyEnum.None:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.None
                    );
                    break;
                case DifficultyEnum.EASY:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.EASY
                    );
                    break;
                case DifficultyEnum.MEDIUM:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.MEDIUM
                    );
                    break;
                case DifficultyEnum.HARD:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.HARD
                    );
                    break;
            }

            return result;
        }

        private List<SelectListItem>? GetTopicSelectList(Question? question)
        {
            // NOTE:(akotro) Is this Include needed here?
            // var topics = _context.Topics.Include(t => t.Certificates).ToList();
            var topics = _context.Topics.ToList();
            if (topics == null || topics.Count <= 0)
                return null;

            var result = new List<SelectListItem>();
            var group = new SelectListGroup();

            foreach (var topic in topics)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = group,
                    Selected = false,
                    Text = $@"{topic.Name}",
                    Value = topic.Id.ToString()
                };

                if (question?.Topic == topic)
                {
                    selectListItem.Selected = true;
                }

                result.Add(selectListItem);
            }

            if (question == null)
            {
                result.ElementAt(0).Selected = true;
            }

            return result;
        }

        private void PopulateQuestion(Question question, int topicId)
        {
            question.DifficultyLevel = GetDifficultyLevel(question);
            question.Topic = _context.Topics.Find(topicId);
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return _context.Question != null
                ? View(
                    await _context.Question
                        .Include(q => q.DifficultyLevel)
                        .Include(q => q.Topic)
                        .ToListAsync()
                )
                : Problem("Entity set 'ApplicationDbContext.Question'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.DifficultyLevel)
                .Include(q => q.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData.Add("Topic", GetTopicSelectList(null));

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Text,DifficultyLevel")] Question question,
            [Bind("Topic")] int topic
        )
        {
            if (ModelState.IsValid)
            {
                PopulateQuestion(question, topic);

                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.DifficultyLevel)
                .Include(q => q.Topic)
                .FirstOrDefaultAsync(q => q.Id == id);

            ViewData.Add("Topic", GetTopicSelectList(question));

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Text,DifficultyLevel")] Question question,
            [Bind("Topic")] int topic
        )
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PopulateQuestion(question, topic);

                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Question == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Question'  is null.");
            }

            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return (_context.Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
