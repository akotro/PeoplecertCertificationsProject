namespace ModelLibrary.Models.DTO.CandidateExam;

public class CandidateExamAnswersDto
{
    public int Id { get; set; }
    public string? CorrectOption { get; set; }
    public string? ChosenOption { get; set; }
    public bool? IsCorrect { get; set; }
    public bool? IsCorrectModerated { get; set; }
    public CandidateExamDto? CandidateExam { get; set; }
}
