using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Interfaces;

namespace CV19Main.Models.Decanat
{
    internal class Student : IEntity
    {
        public string Name { get; set; }
        public string SureName { get; set; }

        public int Id { get; set; }

        public DateTime Birthday { get; set; }
        public double Rating { get; set; }

        public string Description { get; set; }
    }
}