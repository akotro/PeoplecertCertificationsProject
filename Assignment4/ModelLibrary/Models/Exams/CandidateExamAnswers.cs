namespace ModelLibrary.Models.Exams;

public class CandidateExamAnswers
{
    public int Id { get; set; }
    public string? CorrectOption { get; set; }
    public string? ChosenOption { get; set; }
    public bool? IsCorrect { get; set; }

    public int CandidateExamId { get; set; }
    public virtual CandidateExam? CandidateExam { get; set; }
}
