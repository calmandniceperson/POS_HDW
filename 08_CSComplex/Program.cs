/*
 * Author(s): Michael Koeppl
 */

using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Complex number calculator");

            var num1 = new ComplexNum(2, 3);
            var num2 = new ComplexNum(3, 4);

            Console.WriteLine((num1+num2).ToString());
        }
    }
}
