using ModelLibrary.Models.DTO.Exams;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Certificates;

public class CertificateDto
{
    // [Required]
    public int Id { get; set; }
    // [Required, StringLength(100)]
    public string? Title { get; set; }
    // [StringLength(50)]
    public string? Description { get; set; }
    // [StringLength(50)]
    public string? Category { get; set; }
    // [Required]
    public bool? Active { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<TopicDto>? Topics { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<ExamDto>? Exams { get; set; }
}
