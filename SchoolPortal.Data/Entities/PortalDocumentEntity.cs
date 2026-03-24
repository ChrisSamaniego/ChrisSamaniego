namespace SchoolPortal.Data.Entities;

public class PortalDocumentEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string Base64Content { get; set; } = string.Empty;

    public Guid UploadedByUserId { get; set; }
    public UserEntity? UploadedByUser { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
