using System;

class Program
{
    static void Main(string[] args)
    {
        //Creating new instances of our class using different constructors
        Fraction f1 = new Fraction();
        Random randomm = new Random();

        for (int i = 0; i < 20; i++)
        {
            int top = randomm.Next(101);
            int bottom = randomm.Next(101);
            f1.SetTop(top);
            f1.SetBottom(bottom);
            Console.WriteLine($"Fraction {i+1}: String: {f1.GetFractionString()} Number: {f1.GetDecimalValue()}");
        }

    }
}