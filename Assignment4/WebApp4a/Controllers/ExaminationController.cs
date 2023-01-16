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
    }
}
