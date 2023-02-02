using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models.DTO.Exams;

namespace ModelLibrary.Models.DTO.CandidateExam
{
    public class CandidateExamDto
    {
        public int Id { get; set; }
        public ExamDto? Exam { get; set; }
        public string ExamCertificateTitle { get; set; }
    }
}
