using Spectre.Console;

namespace LeetCodeProblems.Helpers;

public static class TerminalHelper
{
    public static List<string> PromptProblemSelection()
      => AnsiConsole.Prompt(
           new MultiSelectionPrompt<string>()
               .Title("What problem are you solving?")
               .PageSize(10)
               .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
               .InstructionsText(
                   "[grey](Press [blue]<space>[/] to toggle a problem, " +
                   "[green]<enter>[/] to accept)[/]")
               .AddChoices(Problems));

    private static List<string> Problems
        => LeetCodeService.GetLeetCodeSolutionMethods().Select(m => m.Name).ToList();
}
