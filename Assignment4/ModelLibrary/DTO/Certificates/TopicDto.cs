using ModelLibrary.Models.DTO.Questions;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Certificates;

public class TopicDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<QuestionDto>? Questions { get; set; }
}
