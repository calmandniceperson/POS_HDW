/*
 * Author(s): Michael Koeppl
 */

using System;

namespace ConsoleApplication
{
    class ComplexNum
    {
        public int Real { get; private set; }
        public int Imaginary { get; private set; }

        public ComplexNum(int r, int i)
        {
            Real = r;
            Imaginary = i;
        }

        public static ComplexNum operator +(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum(n1.Real + n2.Real, n1.Imaginary + n2.Imaginary);
        }

        public static ComplexNum operator -(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum(n1.Real - n2.Real, n1.Imaginary - n2.Imaginary);
        }

        public override string ToString()
        {
            return $"{this.ToCartesian()}\n{this.ToPolar()}";
        }

        public string ToCartesian()
        {
            return $"x: {Real}; y: {Imaginary}";
        }

        public string ToPolar()
        {
            double sum = Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
            double angle = Math.Acos(Real/sum);
            double angleDegrees = (angle*180)/Math.PI;
            return $"Length: {sum}; Angle: {angle}; Angle in degrees: {angleDegrees}°";
        }
    }
}