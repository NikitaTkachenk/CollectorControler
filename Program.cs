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

            Console.WriteLine(" --- Collection controler --- ");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Add item to collection.");
                Console.WriteLine("2. Remove item from collection.");
                Console.WriteLine("3. Find an item by name.");
                Console.WriteLine("4. Sorting collection by name.");
                Console.WriteLine("5. Limit for collection.");
                Console.WriteLine("6. Enter in group by names.");
                Console.WriteLine("7. Save only a names collection.");
                Console.WriteLine("8. Output everything.");
                Console.WriteLine();
                Console.WriteLine("0. !Exit!.");
                Console.WriteLine("------------------------------------");

                bool boolWhileChoice = int.TryParse(Console.ReadLine(), out int whileChoice);

                switch (whileChoice)
                {
                    case 1:
                        Console.WriteLine("Please! Enter a product name: ");
                        var inputItemName_Case1 = Console.ReadLine();
                        while (inputItemName_Case1 is null)
                        {
                            inputItemName_Case1 = Console.ReadLine();
                            if(inputItemName_Case1 is null)
                                Console.WriteLine("\t - Error! Name is wrong!");
                        }

                        int inputItemCount_Case1;
                        Console.WriteLine("Please! Enter a product count: ");
                        while (!int.TryParse(Console.ReadLine(), out inputItemCount_Case1))
                        {
                            Console.WriteLine("\t - Error! Count is wrong!");
                            Console.WriteLine("Please! Enter a product count: ");
                        }

                        double inputItemWeight_Case1;
                        Console.WriteLine("Please! Enter a product weight: ");
                        while (!double.TryParse(Console.ReadLine(), out inputItemWeight_Case1))
                        {
                            Console.WriteLine("\t - Error! weight is wrong!");
                            Console.WriteLine("Please! Enter a product weight: ");
                        }
                        
                        AddItem(subjects, inputItemName_Case1, inputItemCount_Case1, inputItemWeight_Case1);
                        Console.WriteLine();
                        Console.WriteLine($"Item: {inputItemName_Case1} has been added! With these parameters, count: {inputItemCount_Case1} and weight: {inputItemWeight_Case1}. Successful!");
                        break;

                    case 2:
                        Console.WriteLine("Please! Enter a product name: ");
                        var inputItemName_Case2 = Console.ReadLine();
                        while (inputItemName_Case2 is null)
                        {
                            inputItemName_Case2 = Console.ReadLine();
                            if(inputItemName_Case2 is null)
                                Console.WriteLine("\t - Error! Name is wrong!");
                        }

                        int inputItemCount_Case2;
                        Console.WriteLine("Please! Enter a product count: ");
                        while (!int.TryParse(Console.ReadLine(), out inputItemCount_Case2))
                        {
                            Console.WriteLine("\t - Error! Count is wrong!");
                            Console.WriteLine("Please! Enter a product count: ");
                        }
                        Console.WriteLine();
                        RemoveItem(subjects, inputItemName_Case2, inputItemCount_Case2);
                        Console.WriteLine();
                        Console.WriteLine("Remove from collection is successful!");
                        break;

                    case 3:
                        Console.WriteLine("Please! Enter a product name: ");
                        var inputItemName_Case3 = Console.ReadLine();
                        while (inputItemName_Case3 is null)
                        {
                            inputItemName_Case3 = Console.ReadLine();
                            if(inputItemName_Case3 is null)
                                Console.WriteLine("\t - Error! Name is wrong!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Find by name is successful!");
                        Console.WriteLine();
                        ForeachOutput(FindItemsByName(inputItemName_Case3, subjects));
                        break;

                    case 4:
                        Console.WriteLine();
                        ForeachOutput(SortByName(subjects));
                        Console.WriteLine();
                        Console.WriteLine("Sorting was added!");
                        break;

                    case 5:
                        int inputLimit;
                        Console.WriteLine("Please! Enter a limit for collection: ");
                        while (!int.TryParse(Console.ReadLine(), out inputLimit))
                        {
                            Console.WriteLine("\t - Error! Count is wrong!");
                            Console.WriteLine("Please! Enter a product count: ");
                        }
                        Console.WriteLine();
                        ForeachOutput(Limit(subjects, inputLimit));
                        Console.WriteLine();
                        Console.WriteLine("Limit was added!");
                        break;

                    case 6:
                        Console.WriteLine();
                        GroupByName(subjects);
                        Console.WriteLine();
                        Console.WriteLine("Groups was added!");
                        break;

                    case 7:
                        Console.WriteLine();
                        ForeachOutput(TakeNames(subjects));
                        Console.WriteLine();
                        Console.WriteLine("Names were added!");
                        break;

                    case 8:
                        Console.WriteLine("Collection was be output. Successful!");
                        Console.WriteLine();
                        ForeachOutput(subjects);
                        break;
                    case 0:
                        return;
                    default:
                    break;
                }
            }
        }

        private static void ForeachOutput(IEnumerable<Subjects> collection)
        {
            foreach(var item in collection)
            {
                Console.WriteLine(item); 
            }
        }

        private static void ForeachOutput(IEnumerable<string> collection)
        {
            foreach(var item in collection)
            {
                Console.WriteLine(item); 
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
