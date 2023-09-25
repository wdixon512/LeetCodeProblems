namespace LeetCodeProblems.Problems.ChampagneTower;
public class Solution
{
    public double ChampagneTower(ChampagneTowerProblem p)
        => ChampagneTower(p.poured, p.queryRow, p.queryGlass);

    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var tower = new Tower();

        tower.Fill(poured);

        return tower.FindValue(query_row, query_glass);
    }
}
