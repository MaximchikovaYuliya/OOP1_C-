using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR_3;

namespace LR_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "August", "May", "January", "November", "February", "March", "December", "June", "April", "September", "July", "October" };

            Console.Write("Input length of month's name: ");
            int n = Int32.Parse(Console.ReadLine());

            var selectedMonths_1 = months.Where(t => t.Length == n);
            if (!selectedMonths_1.Any())
                Console.WriteLine("No such months");
            else
            {
                foreach (string s in selectedMonths_1)
                    Console.Write(s + " ");
                Console.WriteLine();
            }

            string[] summerAndWinterMonths = { "December", "January", "February", "June", "July", "August" };
            var selectedMonths_2 = months.Intersect(summerAndWinterMonths);
            Console.Write("Summer and winter months: ");
            foreach (string s in selectedMonths_2)
                Console.Write(s + " ");
            Console.WriteLine();

            var selectedMonths_3 = from t in months orderby t select t;
            Console.Write("Months in alphabet order: ");
            foreach (string s in selectedMonths_3)
                Console.Write(s + " ");
            Console.WriteLine();

            var selectedMonths_4 = months.Where(t => (t.Length >= 4 && t.Contains("u")));
            Console.Write("Months which have name's length no less than 4 and contain letter - u: ");
            foreach (string s in selectedMonths_4)
                Console.Write(s + " ");
            Console.WriteLine();

            var selectedMonths_5 = months.Where(t => t.StartsWith("J")).Select(p => p.Length).OrderBy(s => s).TakeWhile(t => t < 5).Min();

            List <Circle> circles = new List<Circle>
            {
                new Circle(0, 10, 3),
                new Circle(-5, 5, 2),
                new Circle(10, 2, 2),
                new Circle(9, 5, 1),
                new Circle(0, 0, 3)
            };

            double max = circles.Max(t => t.GetSquare());
            double min = circles.Min(t => t.GetSquare());
            var selectedMaxCircle_2 = circles.Where(t => t.GetSquare() == max);
            var selectedMinCircle_2 = circles.Where(t => t.GetSquare() == min);
            Console.WriteLine("Max circle by square: ");
            foreach (var x in selectedMaxCircle_2)
                Console.WriteLine($"({x.CenterX}, {x.CenterY})");
            Console.WriteLine("Min circle by square: ");
            foreach (var x in selectedMinCircle_2)
                Console.WriteLine($"({x.CenterX}, {x.CenterY})");

            Console.WriteLine("Input radius: ");
            Console.Write("r = ");
            int r = Int32.Parse(Console.ReadLine());
            var selectedCircles_3 = circles.Where(t => t.Radius == r);
            if (!selectedCircles_3.Any())
                Console.WriteLine("No such circles");
            else
            {
                Console.WriteLine("Circles with radius r: ");
                foreach (var x in selectedCircles_3)
                    Console.WriteLine($"({x.CenterX}, {x.CenterY}) ");
            }

            var selectedCircles_4 = circles.Where(t => (t.CenterX > 0 && t.CenterY > 0)).Take(1);
            if (!selectedCircles_4.Any())
                Console.WriteLine("No such circle");
            else
            {
                Console.WriteLine("First quarter circle: ");
                foreach (var x in selectedCircles_4)
                    Console.WriteLine($"({x.CenterX}, {x.CenterY}) ");
            }

            var selectedCircles_5 = circles.OrderBy(t => t.GetSquare());
            Console.WriteLine("Ordered circles by square: ");
            foreach (var x in selectedCircles_5)
                Console.Write($"({x.CenterX}, {x.CenterY}) ");
            Console.WriteLine();

            int[] length = { 1, 5, 3, 9, 7};
            var withJoin = months.Join(length,
                w => w.Length,
                q => q, (w, q) => new { Id = q, month = w });
            foreach (var x in withJoin)
                Console.WriteLine(x);

            Console.ReadKey();
        }
    }
}
