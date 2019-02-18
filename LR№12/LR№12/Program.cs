using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.OutputInFile("LR№9.exe", "LR_9.Boss");
            Reflector.GetMethods("LR№9.exe", "LR_9.Boss");
            Reflector.GetFieldsAndProperties("LR№9.exe", "LR_9.Boss");
            Reflector.GetInterfaces("LR№9.exe", "LR_9.Boss");
            Reflector.GetMethodsWithParameter("LR№9.exe", "LR_9.Boss", typeof(int));

            Reflector.OutputInFile("LR№5.exe", "LR_5_6_7.PortContainer");
            Reflector.GetMethods("LR№5.exe", "LR_5_6_7.PortController");
            Reflector.GetFieldsAndProperties("LR№5.exe", "LR_5_6_7.Captain");
            Reflector.GetInterfaces("LR№5.exe", "LR_5_6_7.Vehicle");
            Reflector.GetMethodsWithParameter("LR№5.exe", "LR_5_6_7.Captain", typeof(string));

            Reflector.OutputInFile(null, "System.Int32");
            Reflector.GetMethods(null, "System.Int32");
            Reflector.GetFieldsAndProperties(null, "System.Int32");
            Reflector.GetInterfaces(null, "System.Int32");
            Reflector.GetMethodsWithParameter(null, "System.Int32", typeof(int));

            Reflector.GetMethods(null, "System.String");
            Reflector.OutputInFile(null, "System.String");
            Reflector.GetFieldsAndProperties(null, "System.String");
            Reflector.GetInterfaces(null, "System.String");
            Reflector.GetMethodsWithParameter(null, "System.String", typeof(int));

            Console.WriteLine();
            Reflector.InvokeMethod(null, "LR_12.Example", "method2");
            Reflector.InvokeMethod(null, "LR_12.Example", "method1");
            Console.ReadKey();
        }
    }
}
