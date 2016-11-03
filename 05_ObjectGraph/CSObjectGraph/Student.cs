using System;
using System.Text;

namespace ConsoleApplication
{
    public class Student: Person
    {
        public DateTime EntryDate { get; set; }
        
        public Student(int id, PersonGender gender, string lastName,
                       string firstName, DateTime birthDate,
                       DateTime entryDate)
                       :base(id, gender, lastName, firstName, birthDate)
        {
            EntryDate = entryDate;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.FirstName} {base.LastName}");
            sb.Append(base.ToString());
            sb.Append($"\tDate of entry: {EntryDate}\n");
            return sb.ToString();
        }
    }
}