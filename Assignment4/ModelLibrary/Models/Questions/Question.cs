using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Exams;

namespace ModelLibrary.Models.Questions;

public class Question
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int TopicId { get; set; }
    public virtual Topic? Topic { get; set; }
    public int DifficultyLevelId { get; set; }
    public virtual DifficultyLevel? DifficultyLevel { get; set; }
    public virtual ICollection<ExamQuestion>? Exams { get; set; }

    public virtual ICollection<Option>?
        Options { get; set; } // NOTE(akotro): Reverse Navigation
}
