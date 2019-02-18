using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace LR_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(Tasks.GetSimpleNumbers, TaskCreationOptions.LongRunning);
            Stopwatch stopwatch = Stopwatch.StartNew();
            task1.RunSynchronously();
            stopwatch.Stop();
            Tasks.GetInfo(task1, stopwatch);

            CancellationTokenSource token = new CancellationTokenSource();
            Task task2 = new Task(Tasks.GetSimpleNumbers, token.Token);
            stopwatch.Restart();
            task2.Start();
            stopwatch.Stop();
            token.Cancel();
            Tasks.GetInfo(task2, stopwatch);

            Task<double> task3 = Task.Run(() => Math.Sin(27) + 1000 / 239 - Math.Sqrt(372));
            Task<double> task4 = Task.Run(() => 700 * (Math.Tan(50) / 43));
            Task<double> task5 = Task.Run(() => Math.Log10(200) - Math.Pow(3.47, 4));
            Task<double> task6 = Task.WhenAny(task3, task4, task5).ContinueWith(t =>
            {
                double res = task3.Result + task4.Result + task5.Result;
                Console.WriteLine("Result = " + res.ToString());
                return res;
            });

            Task<int> task7 = Task.Run(() => Enumerable.Range(1, 100000).Count(n => n % 2 == 0));
            var awaiter = task7.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult(); Console.WriteLine(result);
            });
         
            Task.WaitAll(task6, task7);
            Paralleler.ParallelizeFor();
            Paralleler.ParallelizeForeach();

            Action action = () =>
                {
                    for (int i = 0; i < 10; i++)
                        Console.Write(i);
                    Console.WriteLine();
                };
            Parallel.Invoke(action, action);

            Tasks.GetSimpleNumbersAsync();

            BlockingCollect.store = new BlockingCollection<string>();
            Task pr = new Task(BlockingCollect.Producer);
            Task cn = new Task(BlockingCollect.Consumer);
            pr.Wait(1000);
            cn.Wait(1000);
            pr.Start();
            cn.Start();

            Console.ReadKey();
        }
    }
}
