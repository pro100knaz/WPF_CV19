using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main.Models.Decanat
{
    internal class Student
    {
        public string Name { get; set; }
        public string SureName { get; set; }

        public int Id { get; set; }

        public DateTime Birthday { get; set; }
        public double Rating { get; set; }
    }

    internal class Group
    {
        public string Name { get;set; }
        public ICollection<Student> Students { get; set; }
    }
}
