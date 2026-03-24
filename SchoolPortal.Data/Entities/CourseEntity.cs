namespace SchoolPortal.Data.Entities;

public class CourseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }

    public ICollection<CourseFeeEntity> Fees { get; set; } = new List<CourseFeeEntity>();
    public ICollection<QuestionnaireEntity> TheoreticalExams { get; set; } = new List<QuestionnaireEntity>();
}
