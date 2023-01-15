﻿using System.Configuration;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Questions;

namespace ModelLibrary.Models.Exams;

public class Exam
{
    public int Id { get; set; }

    public int CertificateId { get; set; }
    public virtual Certificate? Certificate { get; set; }
    public virtual ICollection<ExamQuestion>? Questions { get; set; }

    public virtual ICollection<CandidateExam>?
        CandidateExams { get; set; } // NOTE(akotro): Reverse Navigation
}
