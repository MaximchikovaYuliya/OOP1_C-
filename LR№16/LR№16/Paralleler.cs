using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LR_16
{
    public static class Paralleler
    {
        public static void ParallelizeFor()
        {
            int[] arr = new int[1000000];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 5;
            }
            stopwatch.Stop();
            Console.WriteLine("Not parallelized cycle 'for' completed for " + stopwatch.ElapsedMilliseconds + "ms");

            stopwatch.Restart();
            Parallel.For(0, arr.Length, (i) => arr[i] = 5);
            stopwatch.Stop();
            Console.WriteLine("Parallelized cycle 'for' completed for " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static void ParallelizeForeach()
        {
            int[] arr = new int[1000000];
            int count = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var a in arr)
            {
                count++;
            }
            stopwatch.Stop();
            Console.WriteLine("Not parallelized cycle 'foreach' completed for " + stopwatch.ElapsedMilliseconds + "ms");

            stopwatch.Restart();
            count = 0;
            Parallel.ForEach(arr, t => count++);
            stopwatch.Stop();
            Console.WriteLine("Parallelized cycle 'foreach' completed for " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}
