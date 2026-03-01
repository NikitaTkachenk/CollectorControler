using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace linkQtrainning
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var subjects = new List<Subjects>();
            var indexNames = new string[5] {"Phone", "Laptop", "Computer", "Oclock", "Lighter"};

            for(int i = 0; i < 10; i++)
            {
                int rndIndexName = rnd.Next(1,5);
                var subject = new Subjects();

                subject.SetName(indexNames[rndIndexName]);
                subject.SetCount(rnd.Next(1, 100));
                subject.SetWeight(rnd.NextDouble() * rnd.Next(1, 100));

                subjects.Add(subject);
            }

            foreach(var subject in subjects)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine();

            var resultFind = FindSubjectFromCollection("Computer", subjects);

            foreach(var subject in resultFind)
            {
                Console.WriteLine(subject);
            }
        }

        private static IEnumerable<Subjects> FindSubjectFromCollection(string nameCollecton, List<Subjects> collection)
        {
            if(!collection.Any(subject => subject.Name == nameCollecton))
            {
                Console.WriteLine($"Error! We don`t have any subjects like a {nameCollecton}! Retry please!");
                return collection;
            }
            return collection.Where(subject => subject.Name == nameCollecton);
        }
    }
}
