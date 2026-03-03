namespace SchoolPortal.Services;

public class LanguageService
{
    public string CurrentLanguage { get; private set; } = "en";

    public event Action? OnChange;

    public void SetLanguage(string? language)
    {
        var next = string.Equals(language, "es", StringComparison.OrdinalIgnoreCase) ? "es" : "en";
        if (string.Equals(next, CurrentLanguage, StringComparison.Ordinal))
        {
            return;
        }

        CurrentLanguage = next;
        OnChange?.Invoke();
    }

    public string T(string english, string spanish)
    {
        return string.Equals(CurrentLanguage, "es", StringComparison.Ordinal) ? spanish : english;
    }
}
