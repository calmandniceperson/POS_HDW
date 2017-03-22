// Author(s): Michael Koeppl

using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        const int TICKET_SHOP_CAPACITY = 2;
        static List<Person> SimQueue = new List<Person>();
        static int countBeforeElevator, countBeforeEscalator, countInElevator, countOnEscalator, countBeforeTicket, countFinished;
        static int longestTime;

        public static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            for (int i = 0; i < 400; i++)
            {
                Console.Clear();
                string addString = time.Minute < 10 ? "0" : "";
                Console.WriteLine($"{time.Hour}:{addString}{time.Minute.ToString()}");
                
                // Every 3 minutes (subway interval) a subway arrives with 100
                // people in it.
                if (i % Subway.INTERVAL == 0)
                {
                    //Console.WriteLine($"{Subway.COUNT} people arrived via subway.");
                    for (int j = 0; j < Subway.COUNT; j++)
                    {
                        Person p = new Person(i);
                        if (p.TMethod == Person.TransportMethod.ELEVATOR)
                        {
                            countBeforeElevator++;
                        }
                        else if (p.TMethod == Person.TransportMethod.ESCALATOR)
                        {
                            countBeforeEscalator++;
                        }
                        SimQueue.Add(p);
                    }
                }

                // Every minute (car interval) a car arrives with 2 people in it.
                if (i % Car.INTERVAL == 0)
                {
                    //Console.WriteLine($"{Car.COUNT} people arrived by car.");
                    for (int j = 0; j < Car.COUNT; j++)
                    {
                        Person p = new Person(i);
                        if (p.TMethod == Person.TransportMethod.ELEVATOR)
                        {
                            countBeforeElevator++;
                        }
                        else if (p.TMethod == Person.TransportMethod.ESCALATOR)
                        {
                            countBeforeEscalator++;
                        }
                        SimQueue.Add(p);
                    }
                }

                // Every minute something happens in the elevator.
                // Either people get out (if it's at the top) or people
                // get in (if it's at the bottom).
                ManageElevator();
                // Every minute the escalator transports 4000/60 people.
                ManageEscalator();
                // Every minute the ticket shop sells 2 tickets.
                ManageTickets(i);

                PrintQueues();

                time = time.AddMinutes(1);
                Thread.Sleep(300);
            }
        }

        private static void ManageElevator()
        {
            int count = 0;
            Console.WriteLine($"Elevator: {Elevator.Instance.CurrentStatus.ToString()}");
            foreach (var p in SimQueue)
            {
                if (count == Elevator.CAPACITY) { break; }
                if (Elevator.Instance.CurrentStatus == Elevator.Status.TOP)
                {
                    // If a person is currently in the elevator (stage 2 and elevator as transport method),
                    // we send them to the ticket queue.
                    if (p.CurrentStage == Person.Stage.STAGE2 && p.TMethod == Person.TransportMethod.ELEVATOR)
                    {
                        // Send people from the elevator to the queue for tickets
                        // (the next stage).
                        p.CurrentStage++;

                        // Update count trackers
                        countInElevator--;
                        countBeforeTicket++;
                    }
                }
                else
                {
                    // If a person is currently waiting (stage 1) for the elevator (which is predetermined by the
                    // transport method), we move them to the elevator.
                    if (p.CurrentStage == Person.Stage.STAGE1 && p.TMethod == Person.TransportMethod.ELEVATOR)
                    {
                        // Send people waiting for the elevator into the elevator (next stage).
                        p.CurrentStage++;
                    
                        // Update count trackers
                        countBeforeElevator--;
                        countInElevator++;

                        count++;
                    }
                }
            }

            // Send elevator up or down again, depending on where it is.
            if (Elevator.Instance.CurrentStatus == Elevator.Status.BOTTOM)
            {
                Elevator.Instance.CurrentStatus = Elevator.Status.TOP;
            }
            else if (Elevator.Instance.CurrentStatus == Elevator.Status.TOP)
            {
                Elevator.Instance.CurrentStatus = Elevator.Status.BOTTOM;
            }
        }

        private static void ManageEscalator()
        {
            int count = 0;
            foreach (var p in SimQueue)
            {
                if (count== Escalator.CAPACITY_PER_MINUTE) { break; }

                if (p.TMethod == Person.TransportMethod.ESCALATOR)
                {
                    if (count == Escalator.CAPACITY_PER_MINUTE) { break; }

                    if (p.CurrentStage == Person.Stage.STAGE1)
                    {
                        p.CurrentStage++;

                        // Update count trackers
                        countBeforeEscalator--;
                        countOnEscalator++;

                        count++;
                    }
                    else if (p.CurrentStage == Person.Stage.STAGE2)
                    {
                        p.CurrentStage++;

                        // Update count trackers
                        countOnEscalator--;
                        countBeforeTicket++;
                    }
                }
            }
        }

        private static void ManageTickets(int currentMinutes)
        {
            int count = 0;
            for (int i = 0; i < SimQueue.Count; i++)
            {
                //if (count >= 35) // 18 cash desks selling 36 tickets a minute
                if (count >= (13*2)-1) // 13 cash desk selling 2 tickets a minute
                {
                    break;
                }
                if (SimQueue[i].CurrentStage == Person.Stage.STAGE3)
                {
                    SimQueue[i].CurrentStage++;

                    // Set the new longest time.
                    if ((currentMinutes - SimQueue[i].EnterTime) > longestTime)
                    {
                        longestTime = currentMinutes - SimQueue[i].EnterTime;
                    }
                    
                    countBeforeTicket--;
                    countFinished++;
                    count++;
                }
            }
        }

        private static void PrintQueues()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Waiting for elevator:  {countBeforeElevator}");
            sb.AppendLine($"Waiting for escalator: {countBeforeEscalator}");
            sb.AppendLine($"In elevator:           {countInElevator}");
            sb.AppendLine($"On escalator:          {countOnEscalator}");
            sb.AppendLine($"Waiting for tickets:   {countBeforeTicket}");
            sb.AppendLine($"Finished (total):      {countFinished}");
            sb.AppendLine($"Longest time so far:   {longestTime} minutes");
            Console.WriteLine(sb.ToString());
        }
   }
}
