using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    public partial class Circle
    {
        int centerX;
        int centerY;
        int radius;
        readonly int ID;
        const float PI = 3.14159265358979f;
        static int counter = 0;
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Circle c = (Circle)obj;
            return c.centerX == this.centerX && c.centerY == this.centerY && c.radius == this.radius;
        }
        public override int GetHashCode()
        {
            return centerX.GetHashCode() ^ centerY.GetHashCode() ^ radius.GetHashCode();
        }
        public override string ToString()
        {
            return centerX.ToString() + " ," + centerY.ToString() + " ," + radius.ToString();
        }
        public Circle(ref int centerX, ref int CenterY,  ref int r)          //конструктор с параметрами
        {
            this.centerX = centerX;
            this.centerY = CenterY;
            radius = r;
            ID = this.GetHashCode();
            counter++;
        }
        public Circle()                                         //конструктор без параметров
        {
            centerX = 0;
            centerY = 0;
            radius = 0;
            ID = this.GetHashCode();
            counter++;
        }
        public Circle(int x, int y, int r)                      //конструктор с параметром по умолчанию
        {
            centerX = x;
            centerY = y;
            radius = r;
            ID = this.GetHashCode();
            counter++;
        }
        static Circle()                                         //статический конструктор(вызывается только при первом создании экземпляра)
        {
            Console.WriteLine("Создан первый объект");
        }
        private Circle(out int r)                               //закрытый конструктор(не допускает создания объектов)
        {
            r = 0;
        }                              
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 0)
                    radius = 0;
                else
                    radius = value;
            }
        }
        public int CenterX => centerX;
        public int CenterY => centerY;
        public static void DisplayCounter()                     //статический метод
        {
            Console.WriteLine($"Создано {counter} объектов");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 6, b = 1, c = 10;
            Circle circle1 = new Circle(9, 1, 3);
            Circle circle2 = new Circle();
            Circle circle3 = new Circle(1, 1, 2);
            Circle circle4 = new Circle(ref a, ref b, ref c);
            Circle circle5 = new Circle(ref a, ref b, ref c);
            circle1.Radius = 9;
            circle2.Radius = -3;
            Console.WriteLine($"Площадь круга 1 = {circle1.GetSquare()}");
            Console.WriteLine($"Площадь круга 4 = {circle4.GetSquare()}");
            Console.WriteLine($"Длина дуги круга 2 = {circle2.GetLength()}");
            Console.WriteLine($"Длина дуги круга 3 = {circle3.GetLength()}");
            Console.WriteLine($"circle1 == circle2 ? {circle1.Equals(circle2)}");
            Console.WriteLine($"circle4 == circle5 ? {circle4.Equals(circle5)}");
            Console.WriteLine($"Тип circle1 - {circle1.GetType()}");
            Console.WriteLine($"circle5 - {circle5.ToString()}");
            Circle.DisplayCounter();
            Circle[] circles = { circle1, circle2, circle3, circle4, circle5 };
            int lengthOfArray = circles.Length;
            float[] squares = new float[lengthOfArray];
            int[] centersX = new int[lengthOfArray];
            int[] centersY = new int[lengthOfArray];
            for (int i = 0; i < lengthOfArray; i++) 
            {
                squares[i] = circles[i].GetSquare();
                centersX[i] = circles[i].CenterX;
                centersY[i] = circles[i].CenterY;
            }
            float min = squares.Min();
            float max = squares.Max();
            Console.WriteLine($"Наименьшая площадь у окружности {Array.IndexOf(squares, min) + 1}, её площадь = {min}");
            Console.WriteLine($"Наибольшая площадь у окружности {Array.IndexOf(squares, max) + 1}, её площадь = {max}");
            for (int i = 0; i < lengthOfArray; ++i)
                for (int j = i + 1; j < lengthOfArray; ++j) 
                {
                    if (centersX[i] == centersX[j])
                        Console.WriteLine($"Центры окружностей {i + 1} и {j + 1} лежат на одной прямой параллельно Oy");
                    if (centersY[i] == centersY[j])
                        Console.WriteLine($"Центры окружностей {i + 1} и {j + 1} лежат на одной прямой параллельно Ox");
                }
            var circle = new { centerX = 6, centerY = 1, radius = 10 }; //анонимный тип
            Console.ReadKey();
        }
    }
}
