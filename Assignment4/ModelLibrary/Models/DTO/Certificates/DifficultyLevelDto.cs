using ModelLibrary.Models.Certificates;

namespace ModelLibrary.Models.DTO.Certificates;

public class DifficultyLevelDto
{
    public int Id { get; set; }
    public DifficultyEnum? Difficulty { get; set; }
}
