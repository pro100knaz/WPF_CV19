using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Decanat;
using CV19Main.Services.Base;
using CV19Main.Services.Students;

namespace CV19Main.Services
{
    internal class StudentsRepository : RepositoryInMemory<Student>
    {
        public StudentsRepository() : base(TestData.Students)
        {
        }

        protected override void Update(Student source, Student Destination)
        {
            Destination.Name = source.Name;
            Destination.Birthday = source.Birthday;
            Destination.Description = source.Description;
            Destination.SureName = source.SureName;
            Destination.Rating = source.Rating;
        }
    }
}
