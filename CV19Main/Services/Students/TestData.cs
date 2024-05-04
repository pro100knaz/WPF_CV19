using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using CV19Main.Models.Decanat;

namespace CV19Main.Services.Students
{
    static class TestData
    {
        public static Group[] Groups{ get; }  = Enumerable
            .Range(0, 10)
            .Select(i => new Group {Name = $"Группа номер {i}" })
            .ToArray();

        public static Student[] Students { get; } = CreateStudents(Groups);

        private static Student[] CreateStudents(Group[] groups)
        {
   
            var students = new List<Student>(100);

            var rnd = new Random();

            var Index = 1;

            foreach (var group in groups)
            {
                for (var i = 0; i < 100; i++)
                {
                    group.Students.Add(new Student
                    {
                        Name = $"Имя {i}",
                        Description = $"Этот студент был создан под номером {Index}",
                        Rating = rnd.Next(1,43) * 100,
                        SureName = $"Crazy{Index ++}",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * rnd.Next(19,34)))
                    });
                }
            }
            return groups.SelectMany(g => g.Students).ToArray();
        }
    }
}
