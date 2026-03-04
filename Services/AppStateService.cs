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
    public string SidebarColor { get; private set; } = "#edf4ff";
    public string NavTextColor { get; private set; } = "#3f4f69";
    public string NavHoverColor { get; private set; } = "#dfeaff";
    public string NavActiveColor { get; private set; } = "#d3e2ff";
    public string NavIconColor { get; private set; } = "#6e88ad";

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
        switch (preset)
        {
            case "gray":
                SidebarColor = "#edf0f4";
                NavTextColor = "#4f5867";
                NavHoverColor = "#dfe4eb";
                NavActiveColor = "#d3d9e2";
                NavIconColor = "#7f899a";
                break;
            case "purple":
                SidebarColor = "#f2efff";
                NavTextColor = "#4f4472";
                NavHoverColor = "#e6e0ff";
                NavActiveColor = "#dcd3ff";
                NavIconColor = "#7e72a8";
                break;
            case "amber":
                SidebarColor = "#fff6e6";
                NavTextColor = "#6e5530";
                NavHoverColor = "#ffeec9";
                NavActiveColor = "#ffe4af";
                NavIconColor = "#a88445";
                break;
            case "red":
                SidebarColor = "#fff0f0";
                NavTextColor = "#744747";
                NavHoverColor = "#ffdede";
                NavActiveColor = "#ffcfcf";
                NavIconColor = "#a86b6b";
                break;
            default:
                SidebarColor = "#edf4ff";
                NavTextColor = "#3f4f69";
                NavHoverColor = "#dfeaff";
                NavActiveColor = "#d3e2ff";
                NavIconColor = "#6e88ad";
                break;
        }
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
