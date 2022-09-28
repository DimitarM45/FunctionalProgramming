using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople(int.Parse(Console.ReadLine()));

            Func<Person, bool> filter = CreateFilter(Console.ReadLine(), int.Parse(Console.ReadLine()));

            Action<Person> printer = CreatePrinter(Console.ReadLine());

            PrintFilteredPeople(people, filter, printer);
        }

        static List<Person> ReadPeople(int count)
        {
            List<Person> people = new List<Person>();

            for (int i = 1; i <= count; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ");

                people.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
            }

            return people;
        }

        static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            Func<Person, bool> filter;

            switch (condition)
            {
                case "younger":
                    filter = p => p.Age < ageThreshold;
                    break;

                default:
                    filter = p => p.Age >= ageThreshold;
                    break;
            }

            return filter;
        }

        static Action<Person> CreatePrinter(string format)
        {
            Action<Person> printer;

            switch (format)
            {
                case "name":
                    printer = p => Console.WriteLine(p.Name);
                    break;

                case "age":
                    printer = p => Console.WriteLine(p.Age);
                    break;

                default:
                    printer = p => Console.WriteLine($"{p.Name} - {p.Age}");
                    break;
            }

            return printer;
        }

        static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            people = people
                .Where(filter)
                .ToList();

            foreach (Person person in people)
                printer(person);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
