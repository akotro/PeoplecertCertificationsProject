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
    public class CandidateExamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidateExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CandidateExams
        public ActionResult Index()
        {

              //return View(await _context.CandidateExams.ToListAsync());
              return View(GetExam(1));
        }

        // GET: CandidateExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CandidateExams == null)
            {
                return NotFound();
            }

            var candidateExam = await _context.CandidateExams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidateExam == null)
            {
                return NotFound();
            }

            return View(candidateExam);
        }

        private IEnumerable<Question> GetExam(int examId)
        {
            var exam = _context.Exams
                .Include(p => p.Questions)
                .ThenInclude(p => p.Options)
                .Where(p => p.Id == examId).SingleOrDefault();

            return exam.Questions;
        }

        private bool CandidateExamExists(int id)
        {
          return _context.CandidateExams.Any(e => e.Id == id);
        }
    }
}
