using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static School school;
        public static void Main(string[] args)
        {                
            Console.Clear();
            if (!File.Exists("liste.csv"))
            {                    
                Console.WriteLine("File not found");
                return;
            }
            createHTL();
            CSVReader.GetStudents();
            Console.WriteLine(school.ToString());
        }
        
        private static void createHTL()
        {
            Person headMaster = new Person(1, Person.PersonGender.Male,
                                           "BONATZ", "Wilhelm", DateTime.Now);
            school = new School("htl donaustadt", headMaster);
            
            Person headOfFaculty = new Person(2, Person.PersonGender.Male,
                                              "LINDNER", "Gerhard",
                                              DateTime.Now);
            Department informatikDep = new Department("Informatik",
                                                      headOfFaculty);
            school.Departments.Add("Informatik", informatikDep);
        }
    }
}
