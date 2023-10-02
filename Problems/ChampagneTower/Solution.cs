namespace LeetCodeProblems.Problems.ChampagneTower;
public class Solution
{
    public double ChampagneTower(ChampagneTowerProblem p)
        => ChampagneTower(p.poured, p.queryRow, p.queryGlass);

    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var tower = new Tower();

        Console.WriteLine($"CupsRequiredToFillRow: {CupsRequiredToFillRow(query_row)}");

        tower.Fill(poured);

        return tower.FindValue(query_row, query_glass);
    }

    private int TotalCupsInRow(int row)
    {
        var sum = 0;

        for (var i = 1; i <= row; i++)
        {
            sum += i;
        }
        return sum;
    }

    public static double CupsRequiredToFillRow(int row)
    {
        double sum = 0;

        for (var i = 0; i < row; i++)
        {
            sum += Math.Pow(i, 2);
        }

        return sum;
    }
}
