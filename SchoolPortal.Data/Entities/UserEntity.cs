namespace SchoolPortal.Data.Entities;

public class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public UserRoleEntity Role { get; set; } = UserRoleEntity.Student;
    public string Email { get; set; } = string.Empty;

    public ICollection<PortalDocumentEntity> Documents { get; set; } = new List<PortalDocumentEntity>();
}
