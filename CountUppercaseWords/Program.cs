using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapitalLetter = w => char.IsUpper(w[0]);

            string[] capitalWords = Array
                .FindAll(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries), isCapitalLetter);

            Console.WriteLine(string.Join(Environment.NewLine, capitalWords));
        }
    }
}
