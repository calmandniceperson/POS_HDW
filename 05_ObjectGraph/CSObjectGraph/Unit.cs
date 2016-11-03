namespace ConsoleApplication
{
    public class Unit
    {
        public string Name { get; set; }
        public int HeadId { get; set; }
        
        public Unit(string name, Person head)
        {
            Name = name;
            HeadId = head.ID;
        }

    }
}