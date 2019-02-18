using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    public partial class Vector
    {
        int[] vector;

        public int this[int Number]
        {
            get
            {
                return vector[Number];
            }
            set
            {
                vector[Number] = value;
            }
        }

        public Vector(int size)
        {
            CountOfElements = size;
            vector = new int[size];
            Length = this.GetLength();
        }

        public Vector(int size, params object[] parameters)
        {
            CountOfElements = size;
            vector = new int[size];
            for (int i = 0; i < size; i++)
            {
                vector[i] = (int)(parameters[i]);
            }
            Length = this.GetLength();
        }

        public int CountOfElements { get; set; }
        public double Length { get; set; }

        public double GetLength()
        {
            Vector[] temp = new Vector[this.CountOfElements];
            int SumOfSquares = 0;
            for (int i = 0; i < this.CountOfElements; i++)
                SumOfSquares += this[i] * this[i];
            return Math.Sqrt(SumOfSquares);
        }

        public void Display()
        {
            Console.Write("Vector: ( ");
            for (int i = 0; i < this.CountOfElements; i++)
                Console.Write(this.vector[i] + " ");
            Console.WriteLine($") Length: {this.Length}");
        }

        public static Vector operator +(Vector x, Vector y)
        {
            Vector temp = new Vector(x.CountOfElements);
            for (int i = 0; i < temp.CountOfElements; i++)
            {
                temp[i] = x[i] + y[i];
            }
            temp.Length = temp.GetLength();
            return temp;
        }

        public static bool operator >(Vector x, Vector y) => x.Length > y.Length;

        public static bool operator <(Vector x, Vector y) => x.Length < y.Length;

        public static bool operator ==(Vector x, Vector y) => x.Equals(y);

        public static bool operator !=(Vector x, Vector y) => !(x.Equals(y));

        public override bool Equals(Object obj)
        {
            if (obj == null) 
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Vector vector = (Vector)obj;
            return vector.Length == this.Length;
        }

        public override int GetHashCode()
        {
            return vector.GetHashCode() ^ CountOfElements.GetHashCode() ^ Length.GetHashCode();
        }

        public static bool operator true(Vector x)
        {
            if (!(x is null))
                return true;
            else
                return false;
        }

        public static bool operator false(Vector x)
        {
            if (x is null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector Vector1 = new Vector(3);
            Vector Vector2 = new Vector(3, 0, 4, 7);
            Vector Vector3 = new Vector(3);
            Vector Vector4 = new Vector(3, -5, 7, -9);
            Vector Vector5 = null;
            Vector1.Display();
            Vector2.Display();
            Vector3.Display();
            Vector4.Display();
            Vector Sum = Vector2 + Vector4;
            Console.Write("Sum of Vector2 and Vector3 -> "); Sum.Display();
            Console.WriteLine($"Vector2 > Vector4 -> {Vector2 > Vector4}");
            Console.WriteLine($"Vector4 > Vector2 -> {Vector4 > Vector2}");
            Console.WriteLine($"Vector2 < Vector4 -> {Vector2 < Vector4}");
            Console.WriteLine($"Vector4 < Vector2 -> {Vector4 < Vector2}");
            Console.WriteLine($"Vector1 == Vector3 -> {Vector1 == Vector3}");
            Console.WriteLine($"Vector1 == Vector2 -> {Vector1 == Vector2}");
            Console.WriteLine($"Vector1 != Vector3 -> {Vector1 != Vector3}");
            Console.WriteLine($"Vector1 != Vector2 -> {Vector1 != Vector2}");
            if (Vector5)
                Console.WriteLine("Vector 5 doesn't null");
            else
                Console.WriteLine("Vector 5 null");
            if (Vector2)
                Console.WriteLine("Vector 2 doesn't null");
            else
                Console.WriteLine("Vector 2 null");
            Vector[] Vectors = { Vector1, Vector2, Vector3, Vector4};
            Vector max = MathOperation.Max(Vectors);
            Vector min = MathOperation.Min(Vectors);
            Console.Write("Max vector in Vectors -> ");
            max.Display();
            Console.Write("Min vector in Vectors -> ");
            min.Display();
            Console.WriteLine($"Count of elements of Vector1 -> {MathOperation.Length(Vector1)}");
            Vector modifiedVector4 = Vector4.DeletePositiveElements();
            Console.Write("Modified Vector4 without positive elements -> ");
            modifiedVector4.Display();
            String Str = "String for example";
            Console.WriteLine($"Str: {Str}");
            Console.WriteLine($"Truncation of Str from beginning to 5th letter -> {Str.TruncateFromBegin(5)}");
            Console.ReadKey();
        }
    }
}
