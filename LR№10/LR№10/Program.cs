using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using LR_5_6_7;

namespace LR_10
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "student " + Name;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { Name = "Misha", Age = 18 };
            Random random = new Random();

            ArrayList arr = new ArrayList(5);
            for (int i = 0; i < arr.Capacity; i++)
                arr.Add(random.Next(100));  
            arr.Add("string");   
            arr.Add(student);
            arr.RemoveAt(1);
            Console.WriteLine("Collection: " + arr.GetType() + " Count of elements: " + arr.Count);
            foreach (var element in arr)
                Console.Write(element + " ");
            Console.WriteLine();
            arr.IndexOf("string");

            List<long> list = new List<long>();
            for (int i = 0; i < 10; i++)
                list.Add(random.Next(100));
            Console.WriteLine("Collection: " + list.GetType() + " Count of elements: " + list.Count);
            foreach (var element in list)
                Console.Write(element + " ");
            Console.WriteLine();
            Console.WriteLine("Input number of elements you want delete and starting position of deletion:");
            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("p = ");
            int p = Convert.ToInt32(Console.ReadLine());
            list.RemoveRange(n, p);
            list.Add(3);
            list.AddRange(list);

            SortedSet<long> set = new SortedSet<long>(list);
            Console.WriteLine("Collection: " + set.GetType() + " Count of elements: " + set.Count);
            foreach (var element in set)
                Console.Write(element + " ");
            Console.WriteLine();
            Console.WriteLine("Input value which need to find: ");
            long value = Int32.Parse(Console.ReadLine());
            int index = -1;
            for (int i = 0; i < set.Count; i++) 
            {
                if (set.ElementAt(i) == value)
                {
                    index = i + 1;
                    break;
                }
            }
            Console.WriteLine("Index of founded value: " + index);

            Captain Leo = new Captain("Leo", 23);
            Captain John = new Captain("Jonh", 35);
            Captain Ann = new Captain("Ann", 31);

            List<Captain> captains = new List<Captain>
            {
                Leo,
                John,
                Ann
            };
            captains.Remove(Leo);
            captains.Add(Leo);
            Console.WriteLine("Collection: " + captains.GetType() + " Count of elements: " + captains.Count);
            foreach (var element in captains)
                Console.Write(element + " ");
            Console.WriteLine();

            SortedSet<Captain> setOfCaptains = new SortedSet<Captain>(captains);
            Console.WriteLine("Collection: " + setOfCaptains.GetType() + " Count of elements: " + setOfCaptains.Count);
            foreach (var element in setOfCaptains)
                Console.Write(element + " ");
            Console.WriteLine();
            Console.WriteLine("Input student's name which need to find: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input age of student which need to find: ");
            int age = Int32.Parse(Console.ReadLine());
            index = -1;
            for (int i = 0; i < setOfCaptains.Count; i++)
            {
                if (setOfCaptains.ElementAt(i).Name == name && setOfCaptains.ElementAt(i).Age == age) 
                {
                    index = i + 1;
                    break;
                }
            }
            Console.WriteLine("Index of founded value: " + index);

            ObservableCollection<Captain> observableCaptains = new ObservableCollection<Captain>
            {
                new Captain("Billy", 37),
                new Captain("Monika", 43),
                new Captain("Fiona", 33)
            };
            observableCaptains.CollectionChanged += CollectionChanged;
            void CollectionChanged(object sender, NotifyCollectionChangedEventArgs ev)
            {
                switch(ev.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Captain newCaptain = ev.NewItems[0] as Captain;
                        Console.WriteLine($"Added new object: {newCaptain.Name} {newCaptain.Age}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Captain oldCaptain = ev.OldItems[0] as Captain;
                        Console.WriteLine($"Removed object: {oldCaptain.Name} {oldCaptain.Age}");
                        break;
                }
            }
            observableCaptains.RemoveAt(1);
            observableCaptains.Add(new Captain("Dabby", 19));

            Console.ReadKey();
        }
    }
}
