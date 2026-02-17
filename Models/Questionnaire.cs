namespace SchoolPortal.Models;

public class Questionnaire
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public List<QuestionnaireResponse> Responses { get; set; } = new();
}

public class QuestionnaireResponse
{
    public string StudentName { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
