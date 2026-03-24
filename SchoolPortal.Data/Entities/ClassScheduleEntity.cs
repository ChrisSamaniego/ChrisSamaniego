namespace SchoolPortal.Data.Entities;

public class ClassScheduleEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
