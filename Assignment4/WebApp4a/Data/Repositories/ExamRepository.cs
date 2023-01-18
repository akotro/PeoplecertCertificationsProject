using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using System;

namespace WebApp4a.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {

        private ApplicationDbContext _context;

        //public ExamRepository()
        //{
        //    _context = new ApplicationDbContext();
        //}

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// vmavraganis: Async Task to get all the questions with their options related tot he current exam
        /// </summary>
        public async Task<IEnumerable<Question>> GetAllQuestionsAsync(CandidateExam candidateExam)
        {
            var exam = await Task.Run(() => _context.Exams
                .Include(p => p.Questions)
                .ThenInclude(p => p.Options)
                .Where(p => p.Id == 1).SingleOrDefault()); //candidateExam.ExamId

            if (exam != null)
            {
                if (exam.Questions != null)
                {
                    return exam.Questions;
                }
                else
                {
                    // Note(vmavraganis): case no exam is found we return an empty collection so we can handle it later
                    return Enumerable.Empty<Question>();
                }
            }
            else
            {
                return Enumerable.Empty<Question>();
            }
        }

        /// <summary>
        /// vmavraganis: Async Task to add the new examAnswers and update the candidateExam
        /// </summary>
        public async Task<CandidateExam> AddCandidateExam(IEnumerable<string> dropDownOptions, CandidateExam candidateExam)
        {
            candidateExam.MaxScore = candidateExam.Exam.Questions.Count;            
            candidateExam.ReportDate = DateAndTime.Now;
            candidateExam.AssessmentCode = "CB";

            _context.CandidateExams.Update(candidateExam);

            candScore = CalculateFinalScore(dropDownOptions, candidateExam.Exam.Questions, candidateExam);

            candidateExam.CandidateScore = candScore;
            candidateExam.PercentScore = CalculatePercentageScore(candidateExam.Exam.Questions.Count, candScore);
            candidateExam.Result = Passed(candidateExam.Exam.Questions.Count, candScore);

            await _context.SaveChangesAsync();
            return candidateExam;
        }

        /// <summary>
        /// vmavraganis: Calculates the percentage score based on the maxScore and the candidateScore
        /// </summary>
        /// <returns>The percentage score of the candidate</returns>
        private decimal CalculatePercentageScore(int maxScore, int candidateScore)
        {
            return (candidateScore / maxScore) * 100;
        }

        /// <summary>
        /// vmavraganis: Calculates the 65% of both scores (candidate and max)
        /// </summary>
        /// <returns>The passed results for the candidate (bool)</returns>
        private bool Passed(int maxScore, int candidateScore)
        {
            int percentageMaxScore = (int)(maxScore* 65 / 0.01);
            int percentageCandidateScore = (int)(candidateScore * 65 / 0.01);

            if (percentageCandidateScore >= percentageMaxScore)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// vmavraganis: Calculates the final score of the candidate and adds the exam answers entities
        /// </summary>
        /// <returns>The final score of the candidate (score)</returns>
        private int CalculateFinalScore(IEnumerable<string> dropDownOptions, IEnumerable<Question> questions, CandidateExam candidateExam)
        {
            int candidateFinalScore = 0;
            int i = 0; //Note (vmavraganis): counter for the outer foreach to get themapping of the question with the selected user option

            foreach (var question in questions) 
            { 
                string correct = string.Empty;
                string choosen = string.Empty;
                bool? isCorrect = false;
                int counter = 1; //Note (vmavraganis): used to map the selected option with the available options for the question

                foreach (var option in question.Options)
                {
                    if (option.Correct == true) //Note (vmavraganis): sets the correct option
                    {
                        correct = option.Text;
                    }

                    if (counter == Int32.Parse(dropDownOptions.ToList()[i])) //Note(vmavraganis): sets the selected option and the evaluation
                    {
                        choosen = option.Text;
                        isCorrect = option.Correct;
                    }

                    counter++;
                }

                var examAnswers = new CandidateExamAnswers
                {
                    CorrectOption = correct,
                    ChosenOption = choosen,
                    IsCorrect = isCorrect,
                    CandidateExam = candidateExam
                };
                _context.CandidateExamAnswers.Add(examAnswers);
                i++;
            }

            return candidateFinalScore;
        }

        private bool _dispose = false;
        /// <summary>
        /// vmavraganis: Displose method and private field to destroy object when not needed
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (!this._dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._dispose = true;
        }

        void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
