using LeetCodeProblems.Abstractions;
using LeetCodeProblems.Helpers;
using LeetCodeProblems.Problems;
using LeetCodeProblems.Problems.ChampagneTower;
using LeetCodeProblems.Problems.LongestWordChain;
using LeetCodeProblems.Problems.PathWithMaximumProbability;

using System.Runtime.CompilerServices;

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
    private static void ChampagneTower()
    {
        //var testcase1 = TestCaseImportHelper.ImportDataFromFile<ChampagneTowerProblem>("Problems\\ChampagneTower\\TestCase1.json");
        //var testcase2 = TestCaseImportHelper.ImportDataFromFile<ChampagneTowerProblem>("Problems\\ChampagneTower\\TestCase2.json");
        //var testcase3 = TestCaseImportHelper.ImportDataFromFile<ChampagneTowerProblem>("Problems\\ChampagneTower\\TestCase3.json");

        var tests = TestCaseImportHelper.ImportTestsForProblem<ChampagneTowerProblem>(nameof(solution.ChampagneTower));

        Run(tests, t => solution.ChampagneTower(t));
        //Console.WriteLine(champSolution.ChampagneTower(testcase1));
        //Console.WriteLine(champSolution.ChampagneTower(testcase2));
        //Console.WriteLine(solution.ChampagneTower(testcase3));

    }

    public static void Run<T>(IEnumerable<T> tests, Func<T, double> testFunc)
        where T : LeetCodeProblem
    {
        try
        {
            foreach (var test in tests)
            {
                Console.WriteLine(testFunc.Invoke(test));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to run test {ex}");
        }
    }
}
