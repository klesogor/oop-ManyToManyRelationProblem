using EntityTestScaffolding;
using EntityTestScaffolding.Relations;
using EntityTestScaffolding.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Teacher : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public IEnumerable<Student> Students
        {
            get
            {
                return _students.GetRelated(this);
            }
            set
            {
                _students.Attach(this,value);
            }
        }

        private readonly ManyToMany<Teacher, Student> _students;

        public Teacher(string name, string surname): base()
        {
            _students = new ManyToMany<Teacher, Student>();
            Name = name;
            Surname = surname;
            InMemoryRepository<Teacher>.GetInstance().Save(this);
        }
    }
}
