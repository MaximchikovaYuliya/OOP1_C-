using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LR_15
{
    static class ProcessInfo
    {
        public static void GetInfo()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id}");
                    Console.WriteLine($"Name: {process.ProcessName}");
                    Console.WriteLine($"Priority: {process.BasePriority}");
                    Console.WriteLine($"Start time: {process.StartTime}");
                    Console.WriteLine($"Total processor time: {process.TotalProcessorTime}");
                    Console.WriteLine();
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Console.WriteLine("Denied access");
                    Console.WriteLine();
                }
                catch(System.InvalidOperationException)
                {
                    Console.WriteLine("Process completed");
                    Console.WriteLine();
                }
            }
        }
    }
}
