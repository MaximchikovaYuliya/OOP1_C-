using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LR_15
{
    static class DomenInfo
    {
        public static void GetDomainInfo()
        {
            AppDomain appDomain = AppDomain.CurrentDomain;

            Console.WriteLine($"Name: {appDomain.FriendlyName}");
            Console.WriteLine($"Setup info: {appDomain.SetupInformation}");
            Console.WriteLine("Assemblies: ");
            foreach(var assembly in appDomain.GetAssemblies())
            {
                Console.WriteLine($"\t{assembly} ");
            }
            Console.WriteLine();
        }

        public static void CreateNewDomain()
        {
            AppDomain secondDomain = AppDomain.CreateDomain("Second domain");
            secondDomain.Load(new AssemblyName("System.Runtime.Serialization.Primitives"));
            AppDomain.Unload(secondDomain);
        }
    }
}
