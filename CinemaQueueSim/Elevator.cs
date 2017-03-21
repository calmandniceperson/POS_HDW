namespace ConsoleApplication
{
    public class Elevator
    {
        public const int CAPACITY = 20;

        // Altogether the elevator takes 2 minutes for going
        // all the way up (30sec), picking up people (30sec),
        // going down again (30sec), and picking up people there
        // again (30sec).
        public const int TOTAL_TIME = 2; 

        private static Elevator instance;

        private Elevator() 
        {
            CurrentStatus = Status.BOTTOM;
        }

        public static Elevator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Elevator();
                }
                return instance;
            }
        }

        public Status CurrentStatus;

        public enum Status
        {
            TOP,
            BOTTOM,
        }
    }
}