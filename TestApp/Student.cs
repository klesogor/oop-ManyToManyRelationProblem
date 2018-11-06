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
    class Student : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public IEnumerable<Teacher> Teachers
        {
            get
            {
                return _teachers.GetRelated(this);
            }
            set
            {
                _teachers.Attach(this, value);
            }
        }

        private readonly ManyToMany<Teacher, Student> _teachers;

        public Student(string name, string surname):base()
        {
            _teachers = new ManyToMany<Teacher, Student>();
            Name = name;
            Surname = surname;
            InMemoryRepository<Student>.GetInstance().Save(this);
        }
    }
}
