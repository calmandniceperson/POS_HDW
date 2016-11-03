using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class School: Unit
    {
        public Dictionary<string, Department> Departments;
        
        public School(string name, Person head):base(name, head)
        {
            Departments = new Dictionary<string, Department>();
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Department> kvp in Departments)
            {
                sb.Append($"\t--> {kvp.Value.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}