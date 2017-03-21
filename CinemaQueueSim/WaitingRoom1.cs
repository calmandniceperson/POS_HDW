namespace ConsoleApplication
{
    public class WaitingRoom1
    {
        private static WaitingRoom1 instance;

        private WaitingRoom1() {}

        public static WaitingRoom1 Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new WaitingRoom1();
                }
                return instance;
            }
        }
    }
}