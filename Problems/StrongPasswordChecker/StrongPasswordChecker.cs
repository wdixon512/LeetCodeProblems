namespace LeetCodeProblems.Problems.StrongPasswordChecker;

public class PasswordChecker
{
    public int StrongPasswordChecker(string password)
    {
        var pwd = new Password(password);

        return pwd.GetMinimumStrongPasswordSteps();
    }
}
