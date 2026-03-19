namespace SchoolPortal.Models;

public class StaffMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserRole FromRole { get; set; }
    public UserRole ToRole { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
