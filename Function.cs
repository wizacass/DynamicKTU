using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        var solutions = new List<int> {1, 1};
        for (int i = 2; i <= n; i++)
        {
            (int d6, int d3, int d2) = Dividers(i);
            int solution = solutions[d6] + solutions[d3] + solutions[d2] + i;
            solutions.Add(solution);
        }

        return solutions.Last();
    }

    public static int Parallel(int n)
    {
        if (n <= 1) return 1;

        var tasks = new List<Task<int>>
        {
            new Task<int>(() => Parallel(n / 2)),
            new Task<int>(() => Parallel(n / 3)),
            new Task<int>(() => Parallel(n / 6))
        };

        tasks.ForEach(task => task.Start());

        Task.WaitAll(tasks.ToArray());

        return tasks.Sum(task => task.Result) + n;
    }

    private static Tuple<int, int, int> Dividers(int n)
    {
        int n1 = MakeOne(n / 6);
        int n2 = MakeOne(n / 3);
        int n3 = MakeOne(n / 2);

        return new Tuple<int, int, int>(n1, n2, n3);
    }

    private static int MakeOne(int x)
    {
        return x <= 1 ? 1 : x;
    }
}
