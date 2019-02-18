using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    public static class MathOperation
    {
        public static Vector Max(params Vector[] vectors)
        {
            int max = 0;
            Vector maxVector = null;
            foreach (var x in vectors)
            {
                if ((int)x.Length > max)
                {
                    max = (int)x.Length;
                    maxVector = x;
                }
            }
            return maxVector;
        }

        public static Vector Min(params Vector[] vectors)
        {
            int min = (int)(vectors[1].Length);
            Vector minVector = null;
            foreach (var x in vectors)
            {
                if ((int)x.Length < min)
                {
                    min = (int)x.Length;
                    minVector = x;
                }
            }
            return minVector;
        }

        public static int Length(Vector vector) => vector.CountOfElements;

        public static String TruncateFromBegin(this String str, int count) => str.Substring(count);

        public static Vector DeletePositiveElements(this Vector vector)
        {
            int[] temp = new int[vector.CountOfElements]; 
            int k = 0;
            for (int i = 0; i < vector.CountOfElements; i++)
            {
                if (vector[i] < 0)
                {
                    temp[k] = vector[i];
                    k++;
                }
            }
            Vector result = new Vector(k);
            for (int i = 0; i < k; i++)
            {
                result[i] = temp[i];
            }
            result.Length = result.GetLength();
            return result;
        }
    }
}
