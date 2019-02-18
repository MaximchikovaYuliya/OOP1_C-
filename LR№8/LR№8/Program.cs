using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_8
{
    interface IFunctional<T> where T : struct
    {
        MyList<T> Add(T element);
        MyList<T> Delete(T element);
        void Display();
    }

    public class Vector<T> : IFunctional<T> where T : struct
    {
        MyList<T> vector;

        public int CountOfElements { get; set; }
        public double Length { get; set; }

        public T this[int Number]
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

        public double GetLength()
        {
            double SumOfSquares = 0;
            for (int i = 0; i < CountOfElements; i++)
                SumOfSquares += (dynamic)vector[i] * vector[i];
            return Math.Sqrt(SumOfSquares);
        }

        public Vector()
        {
            vector = new MyList<T>(0);
            CountOfElements = 0;
            Length = 0;
        }

        public Vector(params T[] parameters)
        {
            vector = new MyList<T>(parameters.Length);
            vector.AddRange(parameters);
            CountOfElements = vector.Count;     
            Length = GetLength();
        }

        public MyList<T> Add(T element)
        {
            vector.Add(element);
            CountOfElements = vector.Count;
            Length = GetLength();
            return vector;
        }

        public MyList<T> Delete(T element)
        {
            vector.Remove(element);
            CountOfElements = vector.Count;
            Length = GetLength();
            return vector;
        }

        public void Display()
        {
            Console.Write("Vector: ( ");
            for (int i = 0; i < CountOfElements; i++)
                Console.Write(vector[i] + " ");
            Console.WriteLine($") Length: {Length}");
        }

        public void WriteToFile(StreamWriter file)
        {
            for (int i = 0; i < CountOfElements; i++)
                file.Write(vector[i] + " ");
            file.WriteLine();
        }

        public void ReadFromFile(StreamReader file)
        {
            string vector = file.ReadLine();
            if (vector == null)
                throw new EndOfStreamException("End of file.");
            T coordinate;
            string[] coordinates = vector.Split(' ');
            foreach (string x in coordinates)
            {
                coordinate = (T)Convert.ChangeType(x, typeof(T));
                this.vector.Add(coordinate);
            }
            CountOfElements = this.vector.Count;
            Length = GetLength();
        }
    }

    public class MyList<T> : List<T>
    {
        public MyList(int capacity) : base(capacity) { }

        public static MyList<T> operator *(MyList<T> x, MyList<T> y)
        {
            MyList<T> temp = new MyList<T>(x.Count);
            for (int i = 0; i < temp.Count; i++)
            {
                temp[i] = (dynamic)x[i] * y[i];
            }
            return temp;
        }
    }

    public class Vehicle { }

    public class Sailboat : Vehicle { }

    public class PortContainer <T> { }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector<int> vector0 = new Vector<int>();
                Vector<int> vector1 = new Vector<int>(3, 6, 7, 0, -1);
                Vector<double> vector2 = new Vector<double>(3.45, 0.5435, -44.4, 73.4);
                Vector<float> vector3 = new Vector<float>(3.0f);
                Vector<byte> vector4 = new Vector<byte>(3, 5, 7, 9);
                Vector<double> vector5 = new Vector<double>();
                StreamReader streamReader = new StreamReader(@"D:\3_semestr\OOTP\LR№8\Input.txt");
                StreamWriter streamWriter = new StreamWriter(@"D:\3_semestr\OOTP\LR№8\Output.txt");
                vector0.ReadFromFile(streamReader);
                vector5.ReadFromFile(streamReader);
                vector1.WriteToFile(streamWriter);
                vector2.WriteToFile(streamWriter);
                //vector5.ReadFromFile(streamReader);
                streamWriter.Close();
                streamReader.Close();
                vector2.Display();
                vector3.Display(); 
                vector1.Add(3);
                vector4.Delete(3);
                vector0.Display();
                vector1.Display();
                vector4.Display();
                vector5.Display();
                PortContainer<Sailboat> aurora = new PortContainer<Sailboat>();
                PortContainer<Vehicle> claymore = new PortContainer<Vehicle>();
            }
            catch (EndOfStreamException ex)
            {
                Console.WriteLine(ex.Data + " " + ex.TargetSite + " " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data + " " + ex.TargetSite + " " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
