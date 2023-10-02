using LeetCodeProblems.Helpers;
using LeetCodeProblems.Problems.ChampagneTower;
using LeetCodeProblems.Problems.LongestWordChain;
using LeetCodeProblems.Problems.PathWithMaximumProbability;

namespace LeetCodeProblems;

public class Executor
{
    static void Main(string[] args)
    {
        //ClimbingStairsProblem();
        //LongestWordChainProblem();
        //PathWithMaxProbability();
        ChampagneTower();
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
            "C:\\Users\\isagn\\source\\repos\\LeetCodeProblems\\Problems\\LongestWordChain\\TestCases\\LongTestCase1.txt")));

    }
    private static void PathWithMaxProbability()
    {
        var solution = new Problems.PathWithMaximumProbability.Solution();

        var testCase1 = TestCaseImportHelper.ImportDataFromFile<PathWithMaximumProbabilityProblem>("Problems\\PathWithMaximumProbability\\TestCase1.json");
        var testCase2 = TestCaseImportHelper.ImportDataFromFile<PathWithMaximumProbabilityProblem>("Problems\\PathWithMaximumProbability\\TestCase2.json");

        Console.WriteLine(solution.MaxProbability(testCase1));
        Console.WriteLine(solution.MaxProbability(testCase2));
    }
    private static void ChampagneTower()
    {
        var testcase1 = TestCaseImportHelper.ImportDataFromFile<ChampagneTowerProblem>("Problems\\ChampagneTower\\TestCase1.json");
        //var testcase2 = TestCaseImportHelper.ImportDataFromFile<ChampagneTowerProblem>("C:\\Users\\isagn\\source\\repos\\LeetCodeProblems\\Problems\\ChampagneTower\\TestCase2.json");
        var champSolution = new Problems.ChampagneTower.Solution();

        Console.WriteLine(champSolution.ChampagneTower(testcase1));
        //Console.WriteLine(champSolution.ChampagneTower(testcase2));
    }
}
