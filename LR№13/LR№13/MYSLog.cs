using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LR_13
{
    static class MYSLog
    {
        public static void GetLog(string action, string fileName, string path, string time)
        {
            StreamWriter writer = new StreamWriter(@"D:\3_semestr\OOTP\LR№13\MYSlogfile.txt", true);
            writer.WriteLine();
            writer.WriteLine($"*******{action}*******");
            writer.WriteLine($"File or directory name   \t\t--->\t{fileName}");
            writer.WriteLine($"Full path                \t\t--->\t{path}");
            writer.WriteLine($"Date and time            \t\t--->\t{time}");
            writer.Close();
        }

        public static void Search(string dateOrKeyWord)
        {
            StreamReader reader = new StreamReader(@"D:\3_semestr\OOTP\LR№13\MYSlogfile.txt");
            Dictionary<int, string[]> text = new Dictionary<int, string[]>();
            int i = 0;
            string[] str = new string[5];

            while(!reader.EndOfStream)
            {
                for (int k = 0; k < 5; k++)
                    str[k] = reader.ReadLine();
                text.Add(i, (string[])str.Clone());
                i++;
            }
            reader.Close();

            List<int> keys = new List<int>();
            foreach (var x in text)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (x.Value[k].Contains(dateOrKeyWord))
                    {
                        keys.Add(x.Key);
                        break;
                    }

                }
            }

            foreach (var x in keys)
            {
                foreach (var y in text.Where(t => t.Key == x).Select(t => t.Value))
                {
                    foreach (var z in y)

                        Console.WriteLine(z);
                }
            }
        }

        public static int GetCount()
        {
            StreamReader reader = new StreamReader(@"D:\3_semestr\OOTP\LR№13\MYSlogfile.txt");
            Dictionary<int, string[]> text = new Dictionary<int, string[]>();
            int i = 0;
            string[] str = new string[5];

            while (!reader.EndOfStream)
            {
                for (int k = 0; k < 5; k++)
                    str[k] = reader.ReadLine();
                text.Add(i, (string[])str.Clone());
                i++;
            }
            reader.Close();

            return text.Count();
        }

        public static void LeaveForCurrentHour()
        {
            StreamReader reader = new StreamReader(@"D:\3_semestr\OOTP\LR№13\MYSlogfile.txt");
            Dictionary<int, string[]> text = new Dictionary<int, string[]>();
            int i = 0;
            string[] str = new string[5];

            while (!reader.EndOfStream)
            {
                for (int k = 0; k < 5; k++)
                    str[k] = reader.ReadLine();
                text.Add(i, (string[])str.Clone());
                i++;
            }

            List<int> keys = new List<int>();
            foreach (var x in text)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (x.Value[k].Contains(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Hour.ToString()))
                    {
                        keys.Add(x.Key);
                        break;
                    }
                }
            }

            keys.ToArray();
            reader.Close();
            
            StreamWriter writer = new StreamWriter(@"D:\3_semestr\OOTP\LR№13\MYSlogfile.txt", false);
            foreach (var x in keys)
            {
                foreach (var y in text.Where(t => t.Key == x).Select(t => t.Value)) 
                {
                    foreach (var z in y)
                        writer.WriteLine(z);
                }
            }
            
            writer.Close();

            Console.WriteLine("\nDeletion completed");
        }
    }
}
