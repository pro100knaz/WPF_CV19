using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Decanat;
using CV19Main.Services.Base;

namespace CV19Main.Services
{
    internal class StudentsRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student source, Student Destination)
        {
            Destination.Name = source.Name;
            Destination.Birthday = source.Birthday;
            Destination.Description = source.Description;
            Destination.SureName = source.SureName;
            Destination.Rating = source.Rating;
        }
    }

    class GroupRepository : RepositoryInMemory<Group>
    {
        protected override void Update(Group source, Group Destination)
        {
            Destination.Name = source.Name;
            Destination.Description = source.Description;
        }
    }
}
