namespace SchoolPortal.Data.Entities;

public class AdminMessageEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid StudentUserId { get; set; }
    public UserEntity? StudentUser { get; set; }

    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public string? AdminReply { get; set; }
    public DateTime? RepliedAt { get; set; }
}
