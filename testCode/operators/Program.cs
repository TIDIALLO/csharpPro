// See https://aka.ms/new-console-template for more information
using static System.Console;

namespace test.com;

public readonly struct Fraction
{   
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator){
        if (denominator == 0) 
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        }
        num = numerator;
        den = denominator;
     }
        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);
        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);
        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den);
        
        public static Fraction operator /(Fraction a, Fraction b){
            if (b.num == 0){
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }
        public override string ToString() => $"{num} / {den}";
   
}

public static class OperatorOverloading
{
    public static void Main(string[] arg){
        var a = new Fraction(5, 4);
        var b = new Fraction(1, 2);
        WriteLine(-a);   // output: -5 / 4
        WriteLine(a + b);  // output: 14 / 8
        WriteLine(a - b);  // output: 6 / 8
        WriteLine(a * b);  // output: 5 / 8
        WriteLine(a / b);  // output: 10 / 4
    }
}
