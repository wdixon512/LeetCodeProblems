using Newtonsoft.Json;

using static System.IO.Directory;

namespace LeetCodeProblems.Helpers;

public static class TestCaseImportHelper
{
    public static T ImportDataFromFile<T>(string filePath) where T : class
    {
        var currDir = GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", string.Empty);

        var fullPath = Path.Combine(currDir, filePath);

        var fileContents = File.ReadAllText(fullPath);

        var convertedContents = JsonConvert.DeserializeObject<T>(fileContents);

        if (convertedContents != null)
        {
            return convertedContents;
        }

        throw new FormatException($"The contents of the file \"{filePath}\" were unable to be converted to type \"{nameof(T)}\".");
    }
}
