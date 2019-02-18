using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_5_6_7
{
    public sealed partial class PartialClass : Object                          //бесплодный класс
    {
        struct Owner
        {
            public string name;
            public int age;
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Age: {age}");
            }
        }

        public override string ToString()
        {
            Console.WriteLine("Метод ToString");
            return "0";
        }

        public bool Equals()
        {
            Console.WriteLine("Метод Equalse");
            return false;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Метод GetHashCode");
            return 0;
        }

        public new Type GetType()
        {
            Type a = null;
            Console.WriteLine("Метод GetType");
            return a;
        }
    }

    public static class ListExtension
    {
        public static string ListToString(this List<Vehicle> list)
        {
            String str = "";
            foreach (var x in list)
            {
                str += "\n  " + x;
            }
            return str;
        }
    }
}
