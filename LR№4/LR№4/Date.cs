using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    public partial class Vector
    {
        public class Date
        {
            public Date(int day, int month, int year)
            {
                this.Day = day;
                this.Month = month;
                this.Year = year;
            }
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
        }
        Date date = new Date(08, 10, 2018);
    }
}
