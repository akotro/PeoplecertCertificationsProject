using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
        private static int _examId;

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

            _examId = 1;// Need Id from John
            return View(await GetAllQuestionsAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnswers(IEnumerable<bool> DropDownOptions)
        {
            if (ModelState.IsValid)
            {
                var candidateExam = await AddCandidateExam(DropDownOptions);

                return await Task.Run(() => RedirectToAction("Index", "CandidateExam", candidateExam));
            }

            return await Task.Run(() => RedirectToAction("Exam"));
        }

        private async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var exam = await Task.Run(() => _context.Exams
                .Include(p => p.Questions)
                .ThenInclude(p => p.Options)
                .Where(p => p.Id == _examId).SingleOrDefault());

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

        private async Task<CandidateExam> AddCandidateExam(IEnumerable<bool> dropDownOptions)
        {
            bool passed = false;
            int candScore = 0;

            var candidateExam = new CandidateExam
            {
                Result = passed,
                MaxScore = 100,
                PercentScore = 100,
                ExamDate = DateAndTime.Now,
                ReportDate = DateAndTime.Now,
                AssessmentCode = "CB"
            };

            _context.CandidateExams.Add(candidateExam);

            foreach (var item in dropDownOptions)
            {
                if (item == true)
                {
                    candScore++;
                }

                var examAnswers = new CandidateExamAnswers
                {
                    CorrectOption = "correct",
                    ChosenOption = "choosen",
                    IsCorrect = item,
                    CandidateExam = candidateExam
                };

                _context.CandidateExamAnswers.Add(examAnswers);
            }

            candidateExam.CandidateScore = candScore;
            await _context.SaveChangesAsync();
            return candidateExam;
        }
    }
}
