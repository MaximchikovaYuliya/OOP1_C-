using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace LR_16
{
    public static class BlockingCollect
    {
        public static BlockingCollection<string> store;
        static string[] products = new string[] { "fridge", "iron", "TV", "microwave", "oven" };
        static int x = 0;
        public static void Producer()
        {
            for (int producer = 1; producer <= products.Length; producer++)
            {
                store.Add(products[x]);
                Console.WriteLine($"Producer {producer}  add " + products[x]);
                x++;
            }
            store.CompleteAdding();
        }

        public static void Consumer()
        {
            for (int consumer = 1; consumer <= 10; consumer++)
            {
                if (store.TryTake(out products[store.Count]))
                {
                    Console.WriteLine($"Sold product ");
                }
                else
                {
                    Console.WriteLine($"Consumer left...");
                }
            }
        }

    }
}
