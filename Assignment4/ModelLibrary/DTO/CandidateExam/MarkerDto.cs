using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.CandidateExam;

public class MarkerDto
{
    public string AppUserId { get; set; }

    [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<CandidateExamDto>? CandidateExams { get; set; }
}
