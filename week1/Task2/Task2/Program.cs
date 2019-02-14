using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student
    {
        public string name;
        public string id;
        public int year = 1;

        public void incc()
        {
            year++;
        }

        public Student(string nam, string idd)
        {
            name = nam;
            id = idd;
            incc();
            print();

        }
        public Student()
        {
            name = Console.ReadLine();
            id = Console.ReadLine();
            year = int.Parse(Console.ReadLine());
            year++;
            print();

        }
        public void print()
        {
            Console.WriteLine("Student's name: " + name);
            Console.WriteLine("Student's id: " + id);
            Console.WriteLine("Year of Study: " + year);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Ali = new Student("Ali", "18BD111222");
            Student Maks = new Student();
        }
    }
}
