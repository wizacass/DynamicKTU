using System;
using System.Collections.Generic;
using System.Linq;

internal class Function
{
    public static int Recursion(int n)
    {
        if (n <= 1) return 1;

        return Recursion(n / 2) + Recursion(n / 3) + Recursion(n / 6) + n;
    }

    public static int Dynamic(int n)
    {
        if (n <= 1) return 1;

        var list = Divided(new List<int> {n, n, n});
        int sum = list.Sum();
        if (sum >= 6) sum += 3;
        int listSum = sum;
        while (listSum > 3)
        {
            list = Divided(list);
            listSum = list.Sum();
            sum += listSum;
        } 

        return sum + n;
    }

    private static int MakeOne(int x)
    {
        return x <= 1 ? 1 : x;
    }

    private static List<int> Divided(List<int> list)
    {
        if(list.Count != 3) throw new Exception("Invalid List!");

        return new List<int> { list[0] / 2, list[1] / 3, list[2] / 6 }.Select(MakeOne).ToList();
    }
}
