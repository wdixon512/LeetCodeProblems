namespace LeetCodeProblems.Options;

public static class LeetProblems
{
    public const string ChampagneTower = "Champagne Tower";

    public static IEnumerable<string> All
        => typeof(LeetProblems)
            .GetFields()
            .Where(f => f.FieldType == typeof(string))
            .Select(f => f.GetValue(null)?.ToString() ?? string.Empty)
            .Where(f => !string.IsNullOrWhiteSpace(f))
            .ToList() ?? Enumerable.Empty<string>();
}
