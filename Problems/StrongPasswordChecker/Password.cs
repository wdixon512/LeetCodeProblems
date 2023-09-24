namespace LeetCodeProblems.Problems.StrongPasswordChecker;

public class Password
{
    private string password = string.Empty;
    private int passwordLength;

    private bool lengthIsValid = false;
    private bool containsLowerCase = false;
    private bool containsUpperCase = false;
    private bool containsRepeatingChars = false;

    public Password(string password)
    {
        SetPasswordLengthValidity(password);
        var repeats = 0;
        var lastChar = '\0';
        foreach(var c in password)
        {
            if (!containsLowerCase && Char.IsLower(c))
            {
                containsLowerCase = true;
            }

            if (!containsUpperCase && Char.IsUpper(c))
            {
                containsUpperCase = true;
            }

            if (c == lastChar)
            {
                repeats++;
            }

            if (!containsRepeatingChars && repeats >= 3)
            {
                containsRepeatingChars = true;
            }

            lastChar = c;
        }

    }

    //public int GetMinimumStrongPasswordSteps()
    //{
    //    var steps = 0;

    //    if (!lengthIsValid)
    //    {



    //    }
    //}

    private void SetPasswordLengthValidity(string password)
    {
        lengthIsValid = password.Length > 5 && password.Length < 21;
        passwordLength = password.Length;
    }

}
