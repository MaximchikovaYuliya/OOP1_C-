using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{
    public partial class Circle
    {
        public float GetSquare()
        {
            return PI * radius * radius;
        }
        public float GetLength() => 2 * PI * radius;  
    }
}
