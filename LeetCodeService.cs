using LeetCodeProblems.Abstractions;
using LeetCodeProblems.Attributes;
using LeetCodeProblems.Helpers;
using LeetCodeProblems.Problems;
using LeetCodeProblems.Problems.LongestWordChain;
using LeetCodeProblems.Problems.PathWithMaximumProbability;

using System.Reflection;

using static LeetCodeProblems.Helpers.TestCaseImportHelper;

namespace LeetCodeProblems;

public class LeetCodeService
{
    private static Solution solution { get; set; } = new Solution();
    static void Main(string[] args)
    {
        var selections = TerminalHelper.PromptProblemSelection();

        var solutionMethods = selections?
                                .Select(GetRequestedSolutionMethod)
                                .Where(m => m is not null)
                                .ToList();

        if (solutionMethods is null)
        {
            throw new NullReferenceException($"Could not find method any of the selected methods. Did you forget to add the Data attribute?");
        }

        foreach (var method in solutionMethods.Where(m => m is not null))
        {
            RunTestsAgainstMethod(method);
        }
    }

    public static void Run(object? tests, Func<object, object> testFunc)
    {
        try
        {
            if (tests is not null && tests.GetType().GetGenericTypeDefinition() == (typeof(List<>)))
            {
                var testList = (IEnumerable<ILeetCodeProblem>)tests;

                foreach (var test in testList)
                {
                    Console.WriteLine(testFunc.Invoke(test));
                }
            }
            else
            {
                throw new Exception("Tests were not an IEnumerable type.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to run test {ex}");
        }
    }

    private static void RunTestsAgainstMethod(MethodInfo method)
    {
        var firstParam = method!.GetParameters().FirstOrDefault();

        var paramVal = firstParam?.ParameterType;

        MethodInfo? testImporterMethod = typeof(TestCaseImportHelper).GetMethod(nameof(ImportTestsForProblem));

        if (testImporterMethod is not null &&
            paramVal is not null &&
            paramVal.IsAssignableTo(typeof(ILeetCodeProblem)))
        {
            MethodInfo genMethod = testImporterMethod.MakeGenericMethod((dynamic)paramVal);

            var tests = genMethod.Invoke(null, new object[] { method!.Name });

            Run(tests, t => method!.Invoke(solution, new object[] { t }));
        }
    }
    private static MethodInfo? GetRequestedSolutionMethod(string problem)
    {
        var requestedMethod = GetLeetCodeSolutionMethods()
                                .FirstOrDefault(m => m.Name == problem);

        if (DoesMethodHaveLeetCodeProblemParam(requestedMethod))
        {
            return requestedMethod;
        }

        return null;
    }

    public static IEnumerable<MethodInfo> GetLeetCodeSolutionMethods()
        => typeof(Solution)
            .GetMethods()
            .Where(m => m.GetCustomAttributes().Any(a => a.GetType().IsAssignableFrom(typeof(LeetSolutionMethodAttribute))));
    

    private static bool DoesMethodHaveLeetCodeProblemParam(MethodInfo? method)
        => method?
            .GetParameters()
            .FirstOrDefault()?
            .ParameterType
            .IsAssignableTo(typeof(ILeetCodeProblem)) ?? false;
}
