using StudentTeacher.Core.Models;
using StudentTeacher.Extentions;
using StudentTeacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Services
{
    internal class TeacherService : IService
    {
        Teacher[] teachers = { };
        public void Create()
        {
            Teacher teacher = new Teacher();
            Array.Resize(ref teachers, teachers.Length + 1);
            Console.Write("Student Name : ");
            string name = Console.ReadLine();
            Console.Write("Student Surname : ");
            string surname = Console.ReadLine();
            Console.Write("Group No : ");
            string groupNo = Console.ReadLine();

            while (!name.CheckName() || !surname.CheckName() || string.IsNullOrWhiteSpace(groupNo))
            {
                Console.Write("Student Name : ");
                name = Console.ReadLine();
                Console.Write("Student Surname : ");
                surname = Console.ReadLine();
                Console.Write("Group No : ");
                groupNo = Console.ReadLine();
            }
            teacher.Surname = surname;
            teacher.Name = name;
            teacher.GroupNo = groupNo;

            teachers[teachers.Length - 1] = teacher;
        }
        public void Delete()
        {
            if (teachers.Length > 0)
            {
                Console.Write("Please enter ID : ");
                int id = int.Parse(Console.ReadLine());
                foreach (Teacher teacher in teachers)
                {
                    if (id == teacher.Id)
                    {
                        int index = Array.IndexOf(teachers, id);
                        teachers = teachers.Remove(index, teachers.Length - 1);
                        Console.WriteLine("Removing was successful");
                    }
                }
                Console.WriteLine("Not Finding...");
            }
            else
            {
                Console.WriteLine("Teacher List is empty.Please Add Teacher...");
            }
        }
        public void GetById()
        {
            if (teachers.Length > 0)
            {
                Console.Write("Please Add Id : ");
                int id = int.Parse(Console.ReadLine());

                foreach (Teacher teacher in teachers)
                {
                    if (id == teacher.Id)
                    {
                        Console.WriteLine(teacher);
                        return;
                    }
                }
                Console.WriteLine("Not Finding...");
            }
            else { Console.WriteLine("Teacher List is empty.Please Add Teacher..."); }
        }
        public void Show()
        {
            if (teachers.Length > 0)
            {
                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine(teacher);
                    return;
                }
            }
            else { Console.WriteLine("Teacher List is empty.Please Add Teacher..."); }
        }
    }
}
