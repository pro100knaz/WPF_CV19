using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main.Models
{
    internal class PersonalPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PersonalPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"x - {X}; y - {Y}";
        }
    }
}
