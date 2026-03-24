namespace SchoolPortal.Data.Entities;

public class QuestionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionnaireId { get; set; }
    public QuestionnaireEntity? Questionnaire { get; set; }

    public string Prompt { get; set; } = string.Empty;
    public int Order { get; set; }
}
