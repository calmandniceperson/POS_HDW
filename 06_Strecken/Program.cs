/*
 * Author(s): Michael Koeppl
 */

using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static Strecke[] strecken = {
            new Strecke(new Punkt(3, 5), new Punkt(7, 6)),
            new Strecke(new Punkt(3, 6), new Punkt(8, 7)),
            new Strecke(new Punkt(4, 7), new Punkt(9, 7)),
            new Strecke(new Punkt(10, 11), new Punkt(12, 13))
        };


        public static void Main(string[] args)
        {
            Console.Clear();

            int indexWithHighestDistance = 0;
            for (int i = 0; i < strecken.Length; i++)
            {
                if (strecken[i].length() > strecken[indexWithHighestDistance].length())
                {
                    indexWithHighestDistance = i;
                }
                Console.WriteLine(strecken[i].ToString());
            }
            var longestStrecke = findLongest();
            Console.WriteLine($"Punkte mit groesstem Abstand: {longestStrecke.getP1().ToString()}, " +
                $"{longestStrecke.getP2().ToString()}, length: {longestStrecke.length()}");
        }

        private static Strecke findLongest()
        {
            double longestDistance = 0;
            Strecke tempStrecke = null, longestStrecke = null;
            for (int i = 0; i < strecken.Length - 1; i++)
            {
                for (int j = i+1; j < strecken.Length; j++)
                {
                    tempStrecke = new Strecke(strecken[i].getP1(), strecken[j].getP2());
                    if (tempStrecke.length() > longestDistance)
                    {
                        longestStrecke = tempStrecke;
                        longestDistance = longestStrecke.length();
                    }
                }
            }
            return longestStrecke;
        }
    }
}
