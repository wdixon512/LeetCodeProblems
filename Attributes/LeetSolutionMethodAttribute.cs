namespace LeetCodeProblems.Attributes;

public class LeetSolutionMethodAttribute : Attribute
{
    public string ProblemName { get; private set; }
    public LeetSolutionMethodAttribute(string name)
        => ProblemName = name;
}
