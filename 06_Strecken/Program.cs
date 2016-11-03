/*
 * Author(s): Michael Koeppl
 */

using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static Strecke[] strecke = {
            new Strecke(new Punkt(3, 5), new Punkt(7, 6)),
            new Strecke(new Punkt(3, 6), new Punkt(8, 7)),
            new Strecke(new Punkt(4, 7), new Punkt(9, 7)),
            new Strecke(new Punkt(10, 11), new Punkt(12, 13))
        };


        public static void Main(string[] args)
        {
            Console.Clear();

            int indexWithHighestDistance = 0;
            for (int i = 0; i < strecke.Length; i++)
            {
                if (strecke[i].length() > strecke[indexWithHighestDistance].length())
                {
                    indexWithHighestDistance = i;
                }
                Console.WriteLine(strecke[i].ToString());
            }
            Console.WriteLine($"Punkt mit groesstem Abstand: {strecke[indexWithHighestDistance].ToString()}");
        }
    }
}
