using System;
using System.Numerics;

public class ClimbingStairs
{
    // dparray[i] will hold the answer for # of diff ways to climb i stairs. We can calculate i+1 by doing dparray[i] + function for i+1
    //[1, 2, 3, 5, 8, 13, 21]
    // 2^0, 2^1, 2^2 - 1, 2^2 + 1, 2^3, 2^4 - 3, 2^4 + 5
    public int ClimbStairs(int n)
    {
        var initdp = new int[] { 1, 2 };

        return Fibonnaci(initdp, n);
    }

    private int Fibonnaci(int[] arr, int n)
    {
        var arrlen = arr.Length;

        int temp = 0;
        for (var i = arrlen; i < n; i++)
        {
            temp = arr[1] + arr[0];
            arr[0] = arr[1];
            arr[1] = temp;
        }

        return n == 1 ? arr[0] : arr[1];
    }
}