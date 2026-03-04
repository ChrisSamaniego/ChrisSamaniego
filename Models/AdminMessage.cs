namespace SchoolPortal.Models;

public class AdminMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string StudentName { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public string? AdminReply { get; set; }
    public DateTime? RepliedAt { get; set; }
}
