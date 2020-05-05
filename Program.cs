using System;

namespace Formule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Recursion vs Dynamic");
            for (int i = 1; i <= 40; i++)
            {
                int rec = Function.Recursion(i);
                int dyn = Function.Dynamic(i);
                Console.WriteLine($"{i, 3}. {rec,4} {(rec == dyn ? "==" : "!=")} {dyn, -4} {(rec != dyn ? $"Diff: {rec - dyn}" : "")}");
            }
        }
    }
}
