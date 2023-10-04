using LeetCodeProblems.Abstractions;
using LeetCodeProblems.Attributes;
using LeetCodeProblems.Helpers;
using LeetCodeProblems.Problems;
using LeetCodeProblems.Problems.ChampagneTower;
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
        //ClimbingStairsProblem();
        //LongestWordChainProblem();
        //PathWithMaxProbability();
        //ChampagneTower();
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
            var firstParam = method?.GetParameters().FirstOrDefault();

            var paramVal = firstParam?.ParameterType;

            MethodInfo? testImporterMethod = typeof(TestCaseImportHelper).GetMethod(nameof(ImportTestsForProblem));

            if (testImporterMethod is not null &&
                paramVal is not null &&
                paramVal.IsAssignableTo(typeof(LeetCodeProblem)))
            {
                MethodInfo genMethod = testImporterMethod.MakeGenericMethod((dynamic)paramVal);

                var tests = genMethod.Invoke(null, new object[] { method!.Name });

                Run(tests, t => method.Invoke(solution, new object[] { t }));
            }
        }
    }

    private static void ClimbingStairsProblem()
    {
        var climbingStairs = new ClimbingStairs();
        Console.WriteLine(climbingStairs.ClimbStairs(15));
    }
    private static void LongestWordChainProblem()
    {
        var longestWordChain = new LongestWordChain();

        Console.WriteLine(longestWordChain.LongestStrChain(new[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" }));
        Console.WriteLine(longestWordChain.LongestStrChain(new[] { "a", "b", "ba", "bca", "bda", "bdca" }));
        Console.WriteLine(longestWordChain.LongestStrChain(new[] { "abcd", "dbqca" }));
        Console.WriteLine(longestWordChain.LongestStrChain(new[] { "a", "ab", "ac", "bd", "abc", "abd", "abdd" }));
        Console.WriteLine(longestWordChain.LongestStrChain(new[] { "a", "b", "ab", "bac" }));
        Console.WriteLine(longestWordChain.LongestStrChain(TestCaseImportHelper.ImportDataFromFile<string[]>(
            "Problems\\LongestWordChain\\TestCases\\LongTestCase1.txt")));

    }
    private static void PathWithMaxProbability()
    {
        var testCase1 = TestCaseImportHelper.ImportDataFromFile<PathWithMaximumProbabilityProblem>("Problems\\PathWithMaximumProbability\\TestCase1.json");
        var testCase2 = TestCaseImportHelper.ImportDataFromFile<PathWithMaximumProbabilityProblem>("Problems\\PathWithMaximumProbability\\TestCase2.json");

        Console.WriteLine(solution.MaxProbability(testCase1));
        Console.WriteLine(solution.MaxProbability(testCase2));
    }

    public static void Run(object? tests, Func<object, object> testFunc)
    {
        try
        {
            if (tests is not null && tests.GetType().GetGenericTypeDefinition() == (typeof(List<>)))
            {
                var testList = (IEnumerable<LeetCodeProblem>)tests;

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
    private static MethodInfo? GetRequestedSolutionMethod(string problem)
    {
        var requestedMethod = typeof(Solution)
                                .GetMethods()
                                .FirstOrDefault(m => m.GetCustomAttribute<LeetSolutionMethodAttribute>()?.ProblemName == problem);

        if (DoesMethodHaveLeetCodeProblemParam(requestedMethod))
        {
            return requestedMethod;
        }

        return null;
    }

    private static bool DoesMethodHaveLeetCodeProblemParam(MethodInfo? method)
        => method?
            .GetParameters()
            .FirstOrDefault()?
            .ParameterType
            .IsAssignableTo(typeof(LeetCodeProblem)) ?? false;
}
