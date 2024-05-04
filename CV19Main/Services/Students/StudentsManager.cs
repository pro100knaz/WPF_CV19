using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models.Decanat;

namespace CV19Main.Services.Students
{
    class StudentsManager
    {
        private readonly StudentsRepository _students;
        private readonly GroupRepository _groups;

        public IEnumerable<Student> Students => _students.GetAll();
        public IEnumerable<Group> Groups => _groups.GetAll();

        public StudentsManager(StudentsRepository students, GroupRepository groups)
        {
            _students = students;
            _groups = groups;
        }


    }
}
