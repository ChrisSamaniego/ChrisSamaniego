namespace SchoolPortal.Data.Entities;

public class QuestionnaireResponseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionnaireId { get; set; }
    public QuestionnaireEntity? Questionnaire { get; set; }

    public Guid StudentUserId { get; set; }
    public UserEntity? StudentUser { get; set; }

    public string Answer { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public int? Grade { get; set; }
    public string TeacherComments { get; set; } = string.Empty;
    public DateTime? GradedAt { get; set; }
}
