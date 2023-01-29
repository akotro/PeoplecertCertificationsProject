namespace ModelLibrary.Models.DTO.Certificates;

public class CertificateDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? PassingMark { get; set; }
    public int? MaxMark { get; set; }
    public string? Category { get; set; }
    public bool? Active { get; set; }
    public List<TopicDto>? Topics { get; set; }
}
