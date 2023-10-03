using LeetCodeProblems.Problems.ChampagneTower;

namespace LeetCodeProblems.Problems;
public partial class Solution
{
    public double ChampagneTower(ChampagneTowerProblem p)
        => ChampagneTower(p.poured, p.queryRow, p.queryGlass);

    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var tower = new Tower();

        if (poured > tower.CupsRequiredToFillRow(query_row)) return 1;

        tower.Fill(poured);

        return tower.FindValue(query_row, query_glass);
    }
}
