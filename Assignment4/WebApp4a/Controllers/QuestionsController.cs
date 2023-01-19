using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.Questions;
using WebApp4a.Data;
using WebApp4a.Data.Repositories;

namespace WebApp4a.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionsRepository _questionRepository;

        public QuestionsController(IQuestionsRepository questionsRepository)
        {
            _questionRepository = questionsRepository;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return _questionRepository.QuestionsDbSetExists()
                ? View(await _questionRepository.GetAllAsync())
                : Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_questionRepository.QuestionsDbSetExists())
            {
                return NotFound();
            }

            var question = await _questionRepository.GetAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            var questionDto = _questionRepository.CreateDto();

            ViewBag.Topics = _questionRepository.GetTopicsSelectList();
            ViewBag.DifficultyLevels = _questionRepository.GetDifficultyLevelsSelectList();

            return View(questionDto);
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionRepository.AddAsync(questionDto);

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var questionDto = await _questionRepository.CreateDto(id);

            ViewBag.Topics = _questionRepository.GetTopicsSelectList();
            ViewBag.DifficultyLevels = _questionRepository.GetDifficultyLevelsSelectList();

            return View(questionDto);
        }

        // POST: Questions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionRepository.UpdateAsync(id, questionDto);

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_questionRepository.QuestionsDbSetExists())
            {
                return NotFound();
            }

            var question = await _questionRepository.GetAsync(id, false);
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
            if (!_questionRepository.QuestionsDbSetExists())
            {
                return Problem("Entity set 'ApplicationDbContext.Questions' is null.");
            }

            await _questionRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
