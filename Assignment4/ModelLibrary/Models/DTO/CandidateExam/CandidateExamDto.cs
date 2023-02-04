using ModelLibrary.Models.DTO.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.CandidateExam
{
    public class CandidateExamDto
    {
        public int Id { get; set; }
        public ExamDto? Exam { get; set; }
        public bool? Result { get; set; }
        public int? MaxScore { get; set; }
        public decimal? PercentScore { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? CandidateScore { get; set; }
        public string? AssessmentCode { get; set; }
        public string? Voucher { get; set; }
        public bool? IsModerated { get; set; }

        [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public List<CandidateExamAnswersDto>?
        CandidateExamAnswers
        { get; set; }
    }
}
