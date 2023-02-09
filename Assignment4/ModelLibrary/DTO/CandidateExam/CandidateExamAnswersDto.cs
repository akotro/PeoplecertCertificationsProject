using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.CandidateExam;

public class CandidateExamAnswersDto
{
    public int Id { get; set; }
    public string? QuestionText { get; set; }
    public string? CorrectOption { get; set; }
    public string? ChosenOption { get; set; }
    public bool? IsCorrect { get; set; }
    public bool? IsCorrectModerated { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public CandidateExamDto? CandidateExam { get; set; }

    public int? QuestionId { get; set; }
}
