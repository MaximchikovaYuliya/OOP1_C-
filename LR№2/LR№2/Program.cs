using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //примитивные типы
            sbyte sbt = -128;
            short sh = 100;
            int i1 = 10;
            long l = 3213648234;
            byte bt = 0;
            ushort ush = 490;
            uint ui = 687;
            ulong ul = 364926469436;
            char ch = 'T';
            bool bl = false;
            float fl = 4.8F;
            double d = 90.738643;
            decimal dm = 4.87684937445353654M;
            string str = "Hello!";
            object obj = 4;
            //явное приведение типов
            int i2 = (int)ch;
            double db1 = (double)i1;
            ulong ul1 = (ulong)sbt;
            byte bt1 = (byte)i1;
            uint ui1 = (uint)sbt;
            //неявное приведение типов
            double db2 = i1;
            float fl1 = i1;
            int i3 = ch;
            object obj1 = str;
            decimal dm1 = i1;
            //упаковка и распаковка
            object o = i1;
            int i4 = (int)o;
            //неявно типизированная переменная
            var v = 10.0f;   //float
            //nullable
            int? n = null;
            n = 5;
            int t = n ?? 1;
            //Строки
            char[] a = { '1', '2', '3' };
            string s1 = "A,B,C";
            string s2 = new string('a', 10);
            string s3 = new string(a);
            //сравнение строк
            Console.WriteLine(String.Equals(s1, s2));
            Console.WriteLine(s3.CompareTo(s1));
            Console.WriteLine(String.Compare(s3, s2));
            int y;
            Console.WriteLine(s1 + s2);                 //сцепление
            string s4 = string.Copy(s1);                //копирование
            Console.WriteLine(s4.Substring(2, 1));      //выделение подстроки
            char[] delims = ",. \n!?;".ToCharArray();
            string[] chars = s1.Split(delims);          //разделение строки на слова
            Console.WriteLine(s1.Insert(2, s3));        //вставка подстроки в заданную позицию
            Console.WriteLine(s2.Remove(5));            //удаление заданной подстроки
            //пустая строка и null-строка
            string emptyStr = "";
            string nullStr = null;
            Console.WriteLine(emptyStr.Insert(0, s2));
            if (nullStr != emptyStr)
                Console.WriteLine(nullStr + s1);
            //StringBuilder
            StringBuilder sb = new StringBuilder("String", 10);
            sb.Remove(2, 1);                            //удаление определенной позиции
            sb.Append("A");                             //вставка в конец
            sb.Insert(0, "B");                          //вставка в начало
            //Массивы
            int[,] Array = { { 6, 7, 5 }, { 4, 0, 12 }, { 2, 9, -5 } };
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                    Console.Write("{0} ", Array[i, j]);
                Console.WriteLine();
            }
            //двумерный массив
            String[] A = { "ABC", "DEF", "GHI" };
            foreach (var x in A)
                Console.Write(x + "\t");
            Console.WriteLine($"\nДлина массива А: {A.Length}");
            bool flag = true;
            int position;
            do
            {
                Console.Write("Введите позицию элемента в массиве, который вы хотите поменять: ");
                position = Convert.ToInt32(Console.ReadLine());
                flag = true;
                if (position > A.Length || position <= 0)
                {
                    Console.WriteLine("Введена неверная позиция.");
                    flag = false;
                }
            } while (!flag);
            Console.Write("Введите значение нового элемента: ");
            string value = Console.ReadLine();
            A.SetValue(value, --position);
            Console.WriteLine("Новый массив: ");
            foreach (var x in A)
                Console.Write(x + "\t");
            Console.WriteLine();
            //ступенчатый массив
            double[][] jaggedArray = { new double[2], new double[3], new double[4] };
            for (int numberStr = 0; numberStr < 3; numberStr++)
            {
                for (int i = 0; i < jaggedArray[numberStr].Length; i++)
                {
                    Console.Write("Введите значение элемента массива: ");
                    double elementValue = Convert.ToDouble(Console.ReadLine());
                    jaggedArray[numberStr][i] = elementValue;
                }
            }
            foreach (double[] m in jaggedArray)
            {
                foreach (double h in m)
                    Console.Write(" " + h);
                Console.WriteLine();
            }
            //неявно типизированные переменные для хранения строки и массива
            var forString = "String";
            var forArray = new[] { 1, 2, 5, 6 };
            //кортежи
            (int, string, char, string, ulong) cortege = (children: 3, name: "Homer", key: 'J', secondName: "Simpson", age: 38);
            Console.WriteLine($"Кортеж целиком: {cortege}");
            Console.WriteLine($"Кортеж частично: {cortege.Item1} {cortege.Item3} {cortege.Item4}");
            var (one, two, three, four, five) = cortege;    //распаковка кортежа
            (bool, int) cortegeX = (false, 1);
            (int, string, char, string, ulong) cortegeY = (4, "Puppy", 'P', "Jack", 2);
            Console.WriteLine(ValueTuple.Equals(cortege, cortegeX));
            Console.WriteLine(cortege.CompareTo(cortegeY));
            //локальная функция
            (int, int, int, char) LocalFunction(int[] Arr, String s)
            {
                int min = Arr.Min();
                int max = Arr.Max();
                int sum = Arr.Sum();
                char firstLetter = s.First();
                return (max, min, sum, firstLetter);
            }
            LocalFunction(forArray, forString);
            Console.ReadKey();
        }
    }
}