// Author(s): Michael Koeppl

namespace ConsoleApplication
{
    public class Escalator
    {
        public const int CAPACITY_PER_MINUTE = 4000/60;
        const int TOTAL_TIME = 1;

        private static Escalator instance;

        private Escalator() {}

        public static Escalator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Escalator();
                }
                return instance;
            }
        }
    }
}