namespace SchoolPortal.Models;

public class CourseCatalogItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public bool HasPracticalExamStage { get; set; } = true;
    public bool HasTheoreticalExamStage { get; set; } = true;
}
