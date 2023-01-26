namespace ModelLibrary.Models.DTO.Questions;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int? TopicId { get; set; }
    public int? DifficultyLevelId { get; set; }
    public List<OptionDto>? Options { get; set; }
}
