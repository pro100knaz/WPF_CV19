using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public void Update(Student student) => _students.Update(student.Id, student);

        public bool Create(Student student, string groupName)
        {
            if(student is null) throw new ArgumentNullException(nameof(Student));
            
            if(string.IsNullOrWhiteSpace(groupName)) throw new ArgumentException( "Некоректное имя группы",nameof(groupName));

            var group = _groups.Get(groupName);
            if (group is null)
            {
                group = new Group { Name = groupName };

                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    _groups.Add(group);
                });
            }
            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                group.Students.Add(student);
                _students.Add(student);
            });
            return true;
        }
    }
}
