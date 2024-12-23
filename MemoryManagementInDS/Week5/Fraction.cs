using System;

namespace MemoryManagementInDS.Week5
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;

            // Ensure the denominator is positive
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        public static Fraction operator +(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                         a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                         a.Denominator * b.Denominator);

        public static Fraction operator *(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by a fraction with a numerator of zero.");

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator ==(Fraction a, Fraction b) =>
            a.Numerator == b.Numerator && a.Denominator == b.Denominator;

        public static bool operator !=(Fraction a, Fraction b) => !(a == b);

        public static bool operator <(Fraction a, Fraction b) =>
            a.Numerator * b.Denominator < b.Numerator * a.Denominator;

        public static bool operator >(Fraction a, Fraction b) => b < a;

        public static bool operator <=(Fraction a, Fraction b) => !(a > b);

        public static bool operator >=(Fraction a, Fraction b) => !(a < b);

        public override int GetHashCode() =>
        HashCode.Combine(Numerator, Denominator);

        public override bool Equals(object obj) =>
            obj is Fraction fraction && this == fraction;

        public override string ToString() =>
            Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
    }
}