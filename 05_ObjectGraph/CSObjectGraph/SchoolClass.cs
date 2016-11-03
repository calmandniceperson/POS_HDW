using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class SchoolClass: Unit
    {
        public string RoomID { get; set; }
        public List<Student> Students;
        
        public SchoolClass(string name, Person head, string roomID)
                     :base(name, head)
        {
            RoomID = roomID;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Student s in Students)
            {
                sb.Append($"\t--> {s.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}