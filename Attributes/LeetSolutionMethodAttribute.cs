using LeetCodeProblems.Problems;
using LeetCodeProblems.Abstractions;

namespace LeetCodeProblems.Attributes;

/// <summary>
/// A method attribute used for easily running your LeetCode solutions against test cases. <br />
/// NOTE: This attribute ONLY works when placed on a method that fits the following criteria:<br />
/// - The method belongs to class <see cref="Solution"/>. (e.g. public partial class Solution)<br />
/// - The method has 1 parameter that implements a <see cref="ILeetCodeProblem"/>.<br />
/// - The <see cref="ILeetCodeProblem"/> parameter is a model for a test case of that problem.<br />
/// - "Test cases" are held in .JSON files in the same folder as the partial problem <see cref="Solution"/>. <br />
/// </summary>
public class LeetSolutionMethodAttribute : Attribute
{
}
