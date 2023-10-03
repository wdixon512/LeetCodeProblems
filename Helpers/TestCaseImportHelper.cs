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
    public static IEnumerable<T> ImportTestsForProblem<T>(string folder)
    {
        var currDir = GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "\\Problems");

        var folderPath = Path.Combine(currDir, folder);

        // Find all json files in folder
        var files = GetFiles(folderPath, "*.json");

        var testCases = new List<T>();

        foreach (var file in files)
        {
            var fileContents = File.ReadAllText(file);

            try
            {
                var testCase = JsonConvert.DeserializeObject<T>(fileContents);

                if (testCase != null)
                {
                    testCases.Add(testCase);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine($"The contents of the file \"{file}\" were unable to be converted to type \"{nameof(T)}\". \n Exception: {ex}");
            }
        }

        return testCases;
    }
}
