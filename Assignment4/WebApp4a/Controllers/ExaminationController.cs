using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using NuGet.Common;
using WebApp4a.Data;

namespace WebApp4a.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExaminationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Exam()
        {
            // Needs dummy data for candidate exam and a candidate to work (we need it)
            //var candidateExam = await _context.CandidateExams.FindAsync(1);

            //if (candidateExam != null && candidateExam.Candidate != null)
            //{
            //    ViewBag.Title = $"Examination for {candidateExam.Candidate.FirstName} {candidateExam.Candidate.LastName}";
            //} else
            //{
            //    return NotFound();
            //}            

            return View(await GetAllQuestionsAsync(1));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnswers(IEnumerable<string> hiddens)
        {
            if (ModelState.IsValid)
            {
                
            }

            return await Task.Run(() => View(hiddens));
        }

        private async Task<IEnumerable<Question>> GetAllQuestionsAsync(int examId)
        {
            var exam = await Task.Run(() => _context.Exams
                .Include(p => p.Questions)
                .ThenInclude(p => p.Options)
                .Where(p => p.Id == examId).SingleOrDefault());

            if (exam != null)
            {
                if (exam.Questions != null)
                {
                    return exam.Questions;
                }
                else
                {
                    return Enumerable.Empty<Question>();
                }
            }
            else
            {
                return Enumerable.Empty<Question>();
            }
        }
    }
}
