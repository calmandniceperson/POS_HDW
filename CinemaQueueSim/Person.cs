using System;

namespace ConsoleApplication
{
    public class Person
    {
        static Random rnd = new Random();       
        public Stage CurrentStage { get; set; }
        public int EnterTime { get; private set; }
        public TransportMethod TMethod { get; set; }

        public enum TransportMethod
        {
            ESCALATOR,
            ELEVATOR,
        }

        public enum Stage 
        {
            // Waiting (before escalator/elevator)
            STAGE1,
            // Waiting on escalator / in elevator
            STAGE2,
            // Waiting before ticket
            STAGE3,
            // Buying ticket
            STAGE4
        }

        public Person(int enterTime)
        {
            EnterTime = enterTime;
            CurrentStage = Stage.STAGE1;

            if (rnd.Next(0, 5) == 0)
            {
                TMethod = TransportMethod.ELEVATOR;
            }
            else
            {
                TMethod = TransportMethod.ESCALATOR;
            }
        }
    }
}