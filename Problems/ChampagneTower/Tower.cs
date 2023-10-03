namespace LeetCodeProblems.Problems.ChampagneTower;

public class Tower
{
    public Glass[,] Glasses { get; set; }

    public Tower()
    {
        Glasses = new Glass[100, 100];
        Glasses.Initialize();

        PopulateEmptyGlasses();
    }

    private void PopulateEmptyGlasses()
    {
        for (int i = 0; i < Glasses.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Glasses[i, j] = new Glass();
            }
        }
    }

    public void Fill(int cups)
    {
        // Math.Floor(log2(cups)) = # rows filled with 1's
        //var filledRows = ((int)Math.Floor(Math.Log2(cups)));

        //var filledCups = Math.Pow(2, filledRows) - 1;

        //cups -= (int)filledCups;

        FillCup(0, 0, cups);
    }

    public void FillCup(int i, int j, double cups)
    {
        var remainingCups = Glasses[i, j].Fill(cups);

        if (remainingCups > 0)
        {
            FillCup(i + 1, j, remainingCups / 2.0);
            FillCup(i + 1, j + 1, remainingCups / 2.0);
        }
    }

    public double FindValue(int row, int col)
    {
        return Glasses[row, col].Value;
    }

    public double CupsRequiredToFillRow(int row)
    {
        double sum = 0;

        for (var i = 0; i <= row; i++)
        {
            sum += Math.Pow(2, i);
        }

        return sum;
    }
}

public class Glass
{
    public const double Capacity = 1.0;
    public double Value { get; set; } = 0.0;
    public double Fill(double cups)
    {
        if (cups + Value >= Capacity)
        {
            var temp = Capacity - Value;

            Value = Capacity;

            return cups - temp;
        }

        Value += cups;

        return 0;
    }
}
