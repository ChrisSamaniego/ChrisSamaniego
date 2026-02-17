using SchoolPortal.Models;

namespace SchoolPortal.Services;

public class AppStateService
{
    public UserRole CurrentRole { get; private set; } = UserRole.Student;
    public string CurrentStudentName { get; private set; } = "Student One";
    public string? CurrentStudentPhotoDataUrl { get; private set; }

    public event Action? OnChange;

    public void SetRole(UserRole role)
    {
        CurrentRole = role;
        NotifyStateChanged();
    }

    public void SetStudentName(string name)
    {
        CurrentStudentName = string.IsNullOrWhiteSpace(name) ? "Student One" : name.Trim();
        NotifyStateChanged();
    }

    public void SetStudentPhoto(string? photoDataUrl)
    {
        CurrentStudentPhotoDataUrl = string.IsNullOrWhiteSpace(photoDataUrl) ? null : photoDataUrl;
        NotifyStateChanged();
    }

    public string GetStudentInitials()
    {
        var parts = CurrentStudentName
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (parts.Length == 0)
        {
            return "SO";
        }

        if (parts.Length == 1)
        {
            return parts[0][0].ToString().ToUpperInvariant();
        }

        return string.Concat(parts[0][0], parts[^1][0]).ToUpperInvariant();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
