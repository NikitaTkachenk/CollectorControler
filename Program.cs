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

            for(int i = 0; i < 5; i++)
            {
                var subject = new Subjects(indexNames[i], rnd.Next(1, 100), rnd.NextDouble() * rnd.Next(1, 100));
                subjects.Add(subject);
            }

            Console.WriteLine("Collection");

            foreach(var subject in subjects)
            {               
                Console.WriteLine(subject);
            }
                                    
            Console.WriteLine("Find item by name");

            var resultFind = FindItemsByName("Computer", subjects);

            foreach(var subject in resultFind)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("Add item and sort");

            AddItem(subjects, "Mouse", 4, 63);

            foreach(var subject in SortByName(subjects))
            {
                Console.WriteLine(subject);
            }
 
            Console.WriteLine("Limit");

            foreach(var subject in Limit(subjects, 5))
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("Group by name");
            GroupByName(subjects);

            TakeNames(subjects);

            foreach (var subject in TakeNames(subjects))
            {
                Console.WriteLine(subject);
            }

            RemoveItem(subjects, "Computer", 100);

            foreach (var subject in subjects)
            {
                Console.WriteLine(subject);
            }
        }

        private static IEnumerable<Subjects> FindItemsByName(string nameCollection, List<Subjects> collection)
        {
            if(collection is null)
                return Enumerable.Empty<Subjects>();

            return collection.Where(subject => subject.Name == nameCollection);
        }

        private static void AddItem(List<Subjects> collection, string nameSubject, int count, double? weight)
        {
            if(collection is null)
                throw new ArgumentNullException(nameof(collection));

            var result = new Subjects(nameSubject, count, weight);
            collection.Add(result);
        }

        private static Subjects FindItemToReturn(List<Subjects> collection, string nameSubject)
        {
            foreach(var item in collection)
            {
                if(item.Name == nameSubject)
                    return item;
            }
            return null;
        }

        private static void RemoveItem(List<Subjects> collection, string nameSubject, int count)
        {
            if(collection is null)
                throw new ArgumentNullException(nameof(collection));

            if(count <= 0)
                return;

            var item = FindItemToReturn(collection, nameSubject);

            if(item is null)    
                return;
 
            if(item.Count <= count)
                collection.Remove(item);
            else
                item.Decrease(count); 
        } 

        private static IEnumerable<Subjects> SortByName(List<Subjects> collection)
        {
            if(collection is null)
                throw new ArgumentNullException(nameof(collection));

            return collection.OrderBy(s => s.Name).ToList();
        }

        private static IEnumerable<Subjects> Limit(IEnumerable<Subjects> collection, int limit)
        {
            if(collection is null || limit < 0)
                return Enumerable.Empty<Subjects>();
            
            return collection.Take(limit);
        }

        private static void GroupByName(IEnumerable<Subjects> collection)
        {
            if(collection is null)
                throw new ArgumentNullException(nameof(collection));
            
            var groups = collection.GroupBy(s => s.Name);

            foreach(var group in groups)
            {
                Console.WriteLine($"Group: {group.Key}, Count: {group.Count()}");
                foreach(var subject in group)
                {
                    Console.WriteLine($"\tSubject: {subject.Name}, Count: {subject.Count}, Weight: {subject.Weight}");
                }
            }
        }

        private static IEnumerable<string> TakeNames(IEnumerable<Subjects> collection)
        {
            if(collection is null)
                throw new ArgumentNullException(nameof(collection));

            var result = collection.Select(s => s.Name).Distinct();  
            return result;
        } 
    }
}
