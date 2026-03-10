using System.ComponentModel.DataAnnotations;

namespace SchoolPortal.Models;

public class Questionnaire
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string CourseCode { get; set; } = string.Empty;

    [Required]
    public string CourseName { get; set; } = string.Empty;

    public TheoreticalExamType ExamType { get; set; } = TheoreticalExamType.Fundamentals;

    public List<string> Questions { get; set; } = new();

    public List<QuestionnaireResponse> Responses { get; set; } = new();
}

public class QuestionnaireResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string StudentName { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    public int? Grade { get; set; }
    public string TeacherComments { get; set; } = string.Empty;
    public DateTime? GradedAt { get; set; }
}
