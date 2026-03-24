namespace SchoolPortal.Data.Entities;

public class QuestionnaireEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CourseId { get; set; }
    public CourseEntity? Course { get; set; }

    public string Title { get; set; } = string.Empty;
    public TheoreticalExamTypeEntity ExamType { get; set; }

    public ICollection<QuestionEntity> Questions { get; set; } = new List<QuestionEntity>();
    public ICollection<QuestionnaireResponseEntity> Responses { get; set; } = new List<QuestionnaireResponseEntity>();
}
