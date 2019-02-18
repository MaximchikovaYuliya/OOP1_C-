using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace LR_15
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Current time: " + DateTime.Now.ToLocalTime());
        }

        static void Main(string[] args)
        {
            ProcessInfo.GetInfo();

            DomenInfo.GetDomainInfo();
            DomenInfo.CreateNewDomain();

            if(File.Exists("file.txt"))
                File.Delete("file.txt");

            Console.Write("Input number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Thread thread = new Thread(new ParameterizedThreadStart(Threads.Calculation)) { Name = "Second thread" };
            thread.Start(n);
            Threads.GetThreadInfo(thread);

            Thread firstThread = new Thread(new ParameterizedThreadStart(Threads.GetEvenNumbers)) { Priority = ThreadPriority.Highest};
            Thread secondThread = new Thread(new ParameterizedThreadStart(Threads.GetOddNumbers));
            firstThread.Start(n);
            secondThread.Start(n);

            TimerCallback timerCallback = new TimerCallback(PrintTime);
            Timer timer = new Timer(timerCallback, null, 1000, 1000);

            Console.ReadKey();
        }
    }
}
