using SchoolPortal.Models;

namespace SchoolPortal.Services;

public class AppStateService
{
    public UserRole CurrentRole { get; private set; } = UserRole.Student;
    public string CurrentStudentName { get; private set; } = "Student One";
    public string? CurrentStudentPhotoDataUrl { get; private set; }
    public bool IsAuthenticated { get; private set; }

    public event Action? OnChange;

    public bool Login(string username, string password)
    {
        var normalizedUsername = username?.Trim() ?? string.Empty;
        var normalizedPassword = password?.Trim() ?? string.Empty;

        if (string.Equals(normalizedUsername, "test", StringComparison.OrdinalIgnoreCase)
            && string.Equals(normalizedPassword, "test", StringComparison.Ordinal))
        {
            IsAuthenticated = true;
            CurrentRole = UserRole.Student;
            CurrentStudentName = "Student One";
            NotifyStateChanged();
            return true;
        }

        if (string.Equals(normalizedUsername, "teacher", StringComparison.OrdinalIgnoreCase)
            && string.Equals(normalizedPassword, "teacher", StringComparison.Ordinal))
        {
            IsAuthenticated = true;
            CurrentRole = UserRole.Teacher;
            CurrentStudentName = "Teacher";
            NotifyStateChanged();
            return true;
        }

        if (string.Equals(normalizedUsername, "admin", StringComparison.OrdinalIgnoreCase)
            && string.Equals(normalizedPassword, "admin", StringComparison.Ordinal))
        {
            IsAuthenticated = true;
            CurrentRole = UserRole.Administrator;
            CurrentStudentName = "Administrator";
            NotifyStateChanged();
            return true;
        }

        return false;
    }

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

    public void Logout()
    {
        IsAuthenticated = false;
        CurrentRole = UserRole.Student;
        CurrentStudentName = "Student One";
        CurrentStudentPhotoDataUrl = null;
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
