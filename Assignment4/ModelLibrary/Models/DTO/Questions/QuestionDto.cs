using ModelLibrary.Models.DTO.Certificates;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Questions;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int? TopicId { get; set; }

    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public TopicDto? Topic { get; set; }

    public int? DifficultyLevelId { get; set; }
    public DifficultyLevelDto? DifficultyLevel { get; set; }
    public List<OptionDto>? Options { get; set; }
}
