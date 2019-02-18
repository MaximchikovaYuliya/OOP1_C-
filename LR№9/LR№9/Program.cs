using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss boss = new Boss();
            Human human = new Human();
            Equipment equipment = new Equipment();

            boss.TurnOn += human.OnTurnOn;
            boss.TurnOn += equipment.OnTurnOn;
            boss.ToTurnOn(100);
            boss.Upgrade += human.OnUpgrate;
            boss.Upgrade += equipment.OnUpgrate;
            boss.ToUpgrate();
            boss.Upgrade -= human.OnUpgrate;
            boss.ToUpgrate();
            boss.ToTurnOn(50);

            string text = "String ,,         for ,,,    example 1324. Teeeext!";
            Func<string, string> func;
            func = MethodsForString.DeleteCommas;
            Console.WriteLine(func(text));
            func += MethodsForString.FindNumbers;
            Console.WriteLine(func(text));
            func += MethodsForString.RemoveExtraSpaces;
            Console.WriteLine(func(text));
            func += MethodsForString.Reverse;
            Console.WriteLine(func(text));
            Console.ReadKey();
        }
    }
}
