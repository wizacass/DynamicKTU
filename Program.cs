using System;

namespace Formule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recursion vs Dynamic");
            for (int i = 0; i < 6; i++)
            {
                var rec = Function.Recursion(i + 1);
                var dyn = Function.Loop(i + 1);
                Console.WriteLine($"{rec,4} {(rec == dyn ? "==" : "!=")} {dyn}");
            }
        }
    }
}
