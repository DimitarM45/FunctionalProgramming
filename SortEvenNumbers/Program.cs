using System;
using System.Linq;

namespace SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray()));
        }
    }
}
