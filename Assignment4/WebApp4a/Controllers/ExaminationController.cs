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
using WebApp4a.Data.Repositories;

namespace WebApp4a.Controllers
{
    public class ExaminationController : Controller
    {
        private static CandidateExam _candidateExam;

        private readonly IExamRepository _examRepository;

        public ExaminationController(IExamRepository adminrepository)
        {
            _examRepository = adminrepository;
        }

        /// <summary>
        /// vmavraganis: Async Task to create the UI for the candidate examination (questions + options)
        /// </summary>
        public async Task<IActionResult> Exam()
        {
            PopulateDropDownOptions();
            return View(await _examRepository.GetAllQuestionsAsync(_candidateExam));
        }

        /// <summary>
        /// vmavraganis: Async Task to get the selected options from the user in each question (true || false)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnswers(IEnumerable<string> DropDownOptions)
        {
            if (ModelState.IsValid)
            {
                var candidateExam = await _examRepository.AddCandidateExam(DropDownOptions, new CandidateExam());

                return await Task.Run(() => RedirectToAction("Results", "CandidateExam", candidateExam));
            }

            return await Task.Run(() => RedirectToAction("Exam"));
        }

        /// <summary>
        /// vmavraganis: Populates the drop down list with the options 1 to 4 for the user to select one
        /// </summary>
        private void PopulateDropDownOptions()
        {
            var list = new List<SelectListItem>();
            for (var i = 1; i < 5; i++)
                list.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.SelectOptions = list;
        }

    }
}
