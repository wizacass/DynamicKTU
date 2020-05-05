using System;
using System.Collections.Generic;
using System.Linq;

public class Function
{
    public static int Recursion(int n)
    {
        if (n <= 1) return 1;

        return Recursion(n / 2) + Recursion(n / 3) + Recursion(n / 6) + n;
    }

    public static int Dynamic(int n)
    {
        if (n <= 1) return 1;

        int sum = n;

        var list = DividedList(n);
        sum += list.Sum();
        for (int i = 0; i < list.Count; i++)
        {
            int number = list[i];
            while (number > 1)
            {
                var newList = DividedList(number);
                sum += newList.Sum();
                number = newList[i];
            }
        }

        return sum;
    }

    private static List<int> DividedList(int x)
    {
        return Divided(new List<int>(new List<int> {x, x, x}));
    }

    private static int MakeOne(int x)
    {
        return x <= 1 ? 1 : x;
    }

    private static List<int> Divided(List<int> list)
    {
        if (list.Count != 3) throw new Exception("Invalid List!");

        return new List<int> {list[0] / 2, list[1] / 3, list[2] / 6}.Select(MakeOne).ToList();
    }
}
