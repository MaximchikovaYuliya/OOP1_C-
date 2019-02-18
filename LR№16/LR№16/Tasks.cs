using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LR_16
{
    static class Tasks
    {
        public static void GetSimpleNumbers()
        {
            int n = 100;
            bool[] numbers = Enumerable.Repeat(true, n + 1).ToArray();

            for (int i = 2; i * i < n; i++)
            {
                if (numbers[i])
                {
                    for (int j = i * i, k = 0; j < n; k++, j = i * i + k * i)
                    {
                        numbers[j] = false;
                    }
                }
            }

            Console.Write("Simple numbers: ");
            for (int i = 2; i < n; i++)
            {
                if (numbers[i])
                    Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }

        public async static void GetSimpleNumbersAsync()
        {
            await Task.Run(() => GetSimpleNumbers());
        }

        public static void GetInfo(Task task, Stopwatch stopwatch)
        {
            Console.WriteLine("ID: " + task.Id);
            Console.WriteLine("Is completed: " + task.IsCompleted);
            Console.WriteLine("Status: " + task.Status);
            Console.WriteLine("Task completed for " + stopwatch.ElapsedMilliseconds + "ms\n");
        }
    }
}
