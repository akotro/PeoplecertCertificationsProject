using ModelLibrary.Models.DTO.Exams;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Certificates;

public class CertificateDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool? Active { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<TopicDto>? Topics { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<ExamDto>? Exams { get; set; }
}
