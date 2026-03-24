using SchoolPortal.Models;

namespace SchoolPortal.Services;

public class AppStateService
{
    public UserRole CurrentRole { get; private set; } = UserRole.Student;
    public string CurrentStudentName { get; private set; } = "Student One";
    public string? CurrentStudentPhotoDataUrl { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public string BackgroundGradientStart { get; private set; } = "#9ec5ff";
    public string BackgroundGradientEnd { get; private set; } = "#eaf3ff";
    public string SidebarColor { get; private set; } = "#0d1b4d";
    public string NavTextColor { get; private set; } = "#eaf2ff";
    public string NavHoverColor { get; private set; } = "rgba(173, 216, 255, 0.2)";
    public string NavActiveColor { get; private set; } = "#d8ebff";
    public string NavIconColor { get; private set; } = "#c5dcff";

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


    public void SetBackgroundGradient(string startColor, string endColor)
    {
        BackgroundGradientStart = string.IsNullOrWhiteSpace(startColor) ? "#9ec5ff" : startColor.Trim();
        BackgroundGradientEnd = string.IsNullOrWhiteSpace(endColor) ? "#eaf3ff" : endColor.Trim();
        ApplyNavigationHarmony("blue");
        NotifyStateChanged();
    }

    public void SetBackgroundGradientPreset(string preset)
    {
        var key = preset?.Trim().ToLowerInvariant() ?? "blue";

        switch (key)
        {
            case "gray":
                BackgroundGradientStart = "#b7bec8";
                BackgroundGradientEnd = "#eceff4";
                break;
            case "purple":
                BackgroundGradientStart = "#c7c3ff";
                BackgroundGradientEnd = "#f0efff";
                break;
            case "amber":
                BackgroundGradientStart = "#f6c25b";
                BackgroundGradientEnd = "#fff4de";
                break;
            case "red":
                BackgroundGradientStart = "#f29a9a";
                BackgroundGradientEnd = "#ffe8e8";
                break;
            default:
                key = "blue";
                BackgroundGradientStart = "#9ec5ff";
                BackgroundGradientEnd = "#eaf3ff";
                break;
        }

        ApplyNavigationHarmony(key);
        NotifyStateChanged();
    }

    private void ApplyNavigationHarmony(string preset)
    {
        SidebarColor = "#0d1b4d";
        NavTextColor = "#eaf2ff";
        NavHoverColor = "rgba(173, 216, 255, 0.2)";
        NavActiveColor = "#d8ebff";
        NavIconColor = "#c5dcff";
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
