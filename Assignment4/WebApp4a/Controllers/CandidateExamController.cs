using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.Exams;
using WebApp4a.Data;

namespace WebApp4a.Controllers
{
    public class CandidateExamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidateExamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(CandidateExam candidateExam)
        {
            ViewBag.Title = "Results";
            return await Task.Run(() =>View(candidateExam));
        }
    }
}
