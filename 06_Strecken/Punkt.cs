namespace ConsoleApplication
{
    public class Punkt
    {
        private int x, y;

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        override public string ToString()
        {
            return $"Punkt  [x={x}, y={y}";
        }
    }
}