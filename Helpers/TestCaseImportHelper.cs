using Newtonsoft.Json;

namespace LeetCodeProblems.Helpers;

public static class TestCaseImportHelper
{
    public static T ImportDataFromFile<T>(string filePath) where T : class
    {
        var fileContents = File.ReadAllText(filePath);

        var convertedContents = JsonConvert.DeserializeObject<T>(fileContents);

        if (convertedContents != null)
        {
            return convertedContents;
        }

        throw new FormatException($"The contents of the file \"{filePath}\" were unable to be converted to type \"{nameof(T)}\".");
    }
}
