using System;
using System.IO;

namespace ConsoleApplication
{
    class CSVReader
    {
        public static void GetStudents()
        {
            Student s = null;
            string[] lines = File.ReadAllLines("liste.csv");
            foreach (var line in lines)
            {
                string[] pieces = line.Split(',');
                
                s = new Student(int.Parse(pieces[0]),
                                Person.PersonGender.Female, pieces[1],
                                pieces[2], Convert.ToDateTime(pieces[4]),
                                DateTime.Now);
                                
                if (!Program.school.Departments.ContainsKey("Informatik"))
                {                        
                    Console.WriteLine("No department informatik");
                    return;
                }

                if (!Program.school.Departments["Informatik"].Classes.ContainsKey(pieces[3]))
                {
                    Person head = new Person(0, Person.PersonGender.Female,
                                             "CLASS", "Head of", DateTime.Now);
                    SchoolClass sc = new SchoolClass(pieces[3], head, "D302");
                }
                Program.school.Departments["Informatik"].Classes[pieces[3]].Students.Add(s);
            }
        }
    }
}