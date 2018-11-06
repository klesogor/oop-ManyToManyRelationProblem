using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vasya = new Student("Vasya", "Test");
            var petya = new Student("Petya", "Test");
            var vova = new Student("Vova", "Test");
            var Petrovich = new Teacher("Petrovich", "Petrovich");
            var Vasilich = new Teacher("Vasilich", "Vasilich");

            Petrovich.Students = new Student[] { vasya, petya, vova };
            vova.Teachers = new Teacher[] { Vasilich };
            Console.WriteLine("Petrovich students");
            foreach (var s in Petrovich.Students)
            {
                Console.WriteLine(s.Name);
            }
            Console.WriteLine("Vasilich students");
            foreach (var s in Vasilich.Students)
            {
                Console.WriteLine(s.Name);
            }
            Console.ReadKey();
        }
    }
}
