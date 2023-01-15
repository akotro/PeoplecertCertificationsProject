using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models.Questions;

namespace ModelLibrary.Models.Exams
{
    public class ExamQuestion
    {
        public int ExamsId { get; set; }
        public virtual Exam? Exam { get; set; }
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }
    }
}
