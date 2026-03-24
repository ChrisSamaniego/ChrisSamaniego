namespace SchoolPortal.Data.Entities;

public class StaffMessageEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserRoleEntity FromRole { get; set; }
    public UserRoleEntity ToRole { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
