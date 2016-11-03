using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class Department: Unit
    {
        public Dictionary<string, SchoolClass> Classes;
        public Department(string name, Person head)
                    :base(name, head)
        {
            Classes = new Dictionary<string, SchoolClass>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, SchoolClass> kvp in Classes)
            {
                sb.Append($"\t--> {kvp.Value.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}