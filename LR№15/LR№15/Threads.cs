using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace LR_15
{
    static class Threads
    {
        public static void Calculation(object n)
        {
            using (StreamWriter file = new StreamWriter("file.txt", true))
            {
                for (int j = 1; j <= (int)n; j++)
                {
                    Console.Write("Secondary thread ");
                    Console.WriteLine(j);

                    file.Write("Secondary thread ");
                    file.WriteLine(j);

                }
                Console.WriteLine();
                file.WriteLine();
            }
        }

        public static void GetThreadInfo(Thread thread)
        {
            Console.WriteLine("Thread name: {0}", thread.Name);
            Console.WriteLine("Is run: {0}", thread.IsAlive);
            Console.WriteLine("Priority: {0}", thread.Priority);
            Console.WriteLine("State: {0}", thread.ThreadState);
            Console.WriteLine();
        }

        public static void GetEvenNumbers(object n)
        {
            Thread.Sleep(100);
            for (int i = 1; i <= (int)n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("First thread(even) ");
                    Console.WriteLine(i);

                    using (StreamWriter file = new StreamWriter("file.txt", true))
                    {
                        file.Write("First thread(even) ");
                        file.WriteLine(i);
                    }
                }
            }
        }

        public static void GetOddNumbers(object n)
        {
            Thread.Sleep(100);
            //Thread.Sleep(0);
            for (int i = 1; i <= (int)n; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write("Second thread(odd) ");
                    Console.WriteLine(i);

                    using (StreamWriter file = new StreamWriter("file.txt", true))
                    {
                        file.Write("Second thread(odd) ");
                        file.WriteLine(i);
                    }
                }
            }
        }
    }
}
