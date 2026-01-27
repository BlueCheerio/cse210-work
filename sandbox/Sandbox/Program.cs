using System;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        int largest = FindLargeNumber();
        Console.WriteLine($"The largest number is: {largest}");
    }
    static int FindLargeNumber()
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
            bool enter = true;
            List<int> numbers = new List<int>();
            while (enter)
            {
                Console.WriteLine("Enter Number: ");
                string read = Console.ReadLine();
                if (read != "0")
                {
                    int numberinput = int.Parse(read);
                    numbers.Add(numberinput);
                }
                else
                {
                    enter = false;
                }
            }
            int largest = 0;
            foreach (int number in numbers)
            {
                if (number > largest)
                {
                    largest = number;
                }
            }
            return largest;
        }
}