using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Formule
{
    internal class Program
    {
        private const string Dir = "Logs";
        private const string CsvFilePattern = "log {0}.csv";
        private const int Generations = 16;

        private static Func<int, int>[] Functions = {
                Function.Recursion,
                Function.Dynamic,
                Function.Parallel
            };

        private static int CalculateEntries(int i)
        {
            return (int)Math.Pow(2, i);
        }

        private static void Main(string[] args)
        {
            Directory.CreateDirectory(Dir);
            string path = string.Format($"{Dir}/{CsvFilePattern}", DateTime.Now.ToString().Replace('/', '-')).Replace(':', '.');
            using var csvWriter = new StreamWriter(path);
            for (int i = 0; i <= Generations; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.WriteLine($"Running {i}/{Generations} calculation...");
                var results = new List<string>();
                int x = CalculateEntries(i);
                foreach (var func in Functions)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    var sw = new Stopwatch();
                    sw.Start();
                    int result = func(x);
                    sw.Stop();

                    results.Add(sw.ElapsedTicks.ToString());
                }

                csvWriter.WriteLine(results.Aggregate($"{x};", (current, result) => current + $"{result};"));
            }
        }
    }
}
