using System;

namespace ConsoleApplication
{
    public class Strecke
    {
        private Punkt p1, p2;

        public Strecke(Punkt p1, Punkt p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public double length()
        {
            return Math.Round(Math.Sqrt(Math.Pow((p2.getX() - p1.getX()), 2) + Math.Pow((p2.getY() - p1.getY()), 2)), 2);
        }

        override public string ToString()
        {
            return $"Strecke [p1={p1.ToString()}, p2={p2.ToString()}], Laenge: {length()}";
        }
    }
}