using System;
using System.Text;

namespace ConsoleApplication
{
    class Teacher: Person
    {
        public DateTime HireDate { get; set; }
        public SchoolClass SupervisedClass { get; set; }
        public Teacher(int id, PersonGender gender, string lastName,
                       string firstName, DateTime birthDate,
                       DateTime hireDate, SchoolClass supervisedClass)
                       :base(id, gender, lastName, firstName, birthDate)
        {
            HireDate = hireDate;
            SupervisedClass = supervisedClass;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"\tHire date: {HireDate}\n");
            sb.Append($"\tSupervised class: {SupervisedClass.Name}\n");
            return sb.ToString();
        }
    }
}