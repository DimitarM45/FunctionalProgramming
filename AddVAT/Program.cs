using System;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = n => n * 1.2;

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .Select(addVAT)
                .Select(n => $"{n:f2}")));
        }
    }
}
